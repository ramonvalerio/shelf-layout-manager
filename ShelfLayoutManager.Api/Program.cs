using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Application;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Repository;
using ShelfLayoutManager.Infrastructure.Data;

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

builder.Services.AddScoped<IShelfApplication, ShelfApplication>();
builder.Services.AddScoped<ICabinetRepository, CabinetRepository>();

var app = builder.Build();

// Verifica e aplica migrações pendentes, criando o banco de dados se necessário
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
