
using MelaAndGradGroup.onlineShopProgram.data;
using MelaAndGradGroup.onlineShopProgram.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = "Server=localhost;Port=3306;Database=test;User ID=root;Password=;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ProductRepository>();

builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
