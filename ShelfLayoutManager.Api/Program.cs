using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Application.Lanes;
using ShelfLayoutManager.Core.Application.Rows;
using ShelfLayoutManager.Core.Application.Shelfs;
using ShelfLayoutManager.Core.Application.Skus;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.Skus;
using ShelfLayoutManager.Core.Repository;
using ShelfLayoutManager.Core.Services;
using ShelfLayoutManager.Infrastructure.Data;
using ShelfLayoutManager.Infrastructure.Repository;
using ShelfLayoutManager.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add dbContext and ConnectionString
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICabinetApplication, CabinetApplication>();
builder.Services.AddScoped<IRowApplication, RowApplication>();
builder.Services.AddScoped<ILaneApplication, LaneApplication>();
builder.Services.AddScoped<ISkuApplication, SkuApplication>();

builder.Services.AddScoped<ICabinetRepository, CabinetRepository>();
builder.Services.AddScoped<IRowRepository, RowRepository>();
builder.Services.AddScoped<ILaneRepository, LaneRepository>();
builder.Services.AddScoped<ISkuRepository, SkuRepository>();

builder.Services.AddScoped<IJanCodeValidatorService, JanCodeValidatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Shelf Layout Manager V1");
        x.DocumentTitle = "Shelf Layout Manager";
        
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
