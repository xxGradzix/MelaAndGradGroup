//
// using MelaAndGradGroup.onlineShopProgram.data;
// using MelaAndGradGroup.onlineShopProgram.services;
// using Microsoft.EntityFrameworkCore;
//
// var builder = WebApplication.CreateBuilder(args);
//
//
// var connectionString = "Server=localhost;Port=3306;Database=test;User ID=root;Password=;";
//
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//
// builder.Services.AddScoped<ProductRepository>();
//
// builder.Services.AddScoped<ProductService>();
//
// builder.Services.AddControllers();
//
// var app = builder.Build();
//
// app.UseHttpsRedirection();
//
//
// app.UseRouting();
//
// app.UseAuthorization();
//
//
// app.MapControllers();
// app.Run();

using MelaAndGradGroup.onlineShopProgram.data;
using MelaAndGradGroup.onlineShopProgram.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;Port=3306;Database=test;User ID=root;Password=;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors(), ServiceLifetime.Scoped);

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();