using Microsoft.EntityFrameworkCore;
using ProductsApp2.Mappings;
using ProductsApp2.Data;

using ProductsApp2.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProductsAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsAppConnectionString"))
);

builder.Services.AddScoped<IProductsRepository, SQLProductRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
