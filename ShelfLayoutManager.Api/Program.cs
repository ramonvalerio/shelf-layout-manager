using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using ShelfLayoutManager.Core.Application.Cabinets;
using ShelfLayoutManager.Core.Application.Lanes;
using ShelfLayoutManager.Core.Application.Rows;
using ShelfLayoutManager.Core.Application.Shelves;
using ShelfLayoutManager.Core.Application.Skus;
using ShelfLayoutManager.Core.Domain;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Exceptions;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.Skus;
using ShelfLayoutManager.Core.Repository;
using ShelfLayoutManager.Core.Services;
using ShelfLayoutManager.Infrastructure.Data;
using ShelfLayoutManager.Infrastructure.Identity;
using ShelfLayoutManager.Infrastructure.Repository;
using ShelfLayoutManager.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shelf Layout Manager", Version = "v1" });
});

//Add dbContext and ConnectionString
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
    options.UseSqlServer(connectionString);
});

// Add Logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add Identity Services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();

// Add Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
});

// Application Services
builder.Services.AddScoped<IShelfApplication, ShelfApplication>();
builder.Services.AddScoped<ICabinetApplication, CabinetApplication>();
builder.Services.AddScoped<IRowApplication, RowApplication>();
builder.Services.AddScoped<ILaneApplication, LaneApplication>();
builder.Services.AddScoped<ISkuApplication, SkuApplication>();

// Domain Services
builder.Services.AddScoped<ICabinetService, CabinetService>();
builder.Services.AddScoped<IRowService, RowService>();
builder.Services.AddScoped<ILaneService, LaneService>();

// Repositories
builder.Services.AddScoped<ICabinetRepository, CabinetRepository>();
builder.Services.AddScoped<IRowRepository, RowRepository>();
builder.Services.AddScoped<ILaneRepository, LaneRepository>();
builder.Services.AddScoped<ISkuRepository, SkuRepository>();

// Services
builder.Services.AddScoped<IJanCodeValidatorService, JanCodeValidatorService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<NLog.ILogger>(LogManager.GetLogger("DatabaseLogger"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
// Middleware to handle errors
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Shelf Layout Manager V1");
        x.DocumentTitle = "Shelf Layout Manager";
    });
    app.UseDeveloperExceptionPage();
    app.UseCors("AllowSpecificOrigin");
}

app.Map("/error", HandleError);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void HandleError(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;

        // Get the context logger
        var logger = context.RequestServices.GetService<ILogger<Program>>();

        // Check if the exception exists and log accordingly
        if (exception != null)
        {
            // Here you can customize the log message as needed
            logger?.LogError(exception, "Erro processando a requisição: {Message}", exception.Message);
        }

        context.Response.StatusCode = exception switch
        {
            BusinessException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = new { message = exception?.Message };
        await context.Response.WriteAsJsonAsync(response);
    });
}

app.UseExceptionHandler(HandleError);