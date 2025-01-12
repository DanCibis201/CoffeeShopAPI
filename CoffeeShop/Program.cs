using CoffeeShop.Database.SqlServer.AutoMigration;
using CoffeeShop.Database.SqlServer.DependencyInjection;
using CoffeeShop.Infrastructure.Core.DependencyInjection;
using CoffeeShop.Security.AutoMigration;
using CoffeeShop.Security.DependencyInjection;
using CoffeeShop.Security.Models;
using CoffeeShop.Security.Modules;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSecurityDbContext(builder.Configuration.GetConnectionString("SecurityConnection"));
builder.Services.AddCoffeeDbContext(builder.Configuration.GetConnectionString("DatabaseConnection"));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.LoadDependencyModules(
    typeof(CoffeeShop.Database.SqlServer.Module).Assembly,
    typeof(CoffeeShop.Infrastructure.Proxy.Module).Assembly,
    typeof(CoffeeShop.Infrastructure.CoR.Module).Assembly,
    typeof(CoffeeShop.Infrastructure.Observer.Module).Assembly,
    typeof(CoffeeShop.Infrastructure.Creational.Module).Assembly,
    typeof(ModuleServices).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var corsOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(corsOrigins)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.ConfigureDependencyModules(typeof(ModuleBuilders));

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

app.MapIdentityApi<User>();
app.CreateSecurityDbIfDoesNotExist();
app.CreateDbIfDoesNotExist();

app.Run();