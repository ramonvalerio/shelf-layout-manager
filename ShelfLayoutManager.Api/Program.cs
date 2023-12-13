using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Application;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.SKUs;
using ShelfLayoutManager.Core.Repository;
using ShelfLayoutManager.Infrastructure.Data;
using ShelfLayoutManager.Infrastructure.Repository;

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
builder.Services.AddScoped<IRowRepository, RowRepository>();
builder.Services.AddScoped<ILaneRepository, LaneRepository>();
builder.Services.AddScoped<ISKURepository, SKURepository>();

var app = builder.Build();

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
