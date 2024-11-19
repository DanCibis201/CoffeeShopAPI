using CoffeeShop.Database.SqlServer.AutoMigration;
using CoffeeShop.Database.SqlServer.DependencyInjection;
using CoffeeShop.Infrastructure.Core.DependencyInjection;
using CoffeeShop.Security.AutoMigration;
using CoffeeShop.Security.Context;
using CoffeeShop.Security.DependencyInjection;
using CoffeeShop.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
})
.AddCookie(IdentityConstants.ApplicationScheme)
.AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<CoffeeSecurityDbContext>()
    .AddApiEndpoints();

builder.Services.AddSecurityDbContext(builder.Configuration.GetConnectionString("SecurityConnection"));
builder.Services.AddCoffeeDbContext(builder.Configuration.GetConnectionString("DatabaseConnection"));

builder.Services.AddControllers().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.LoadDependencyModules(
    typeof(CoffeeShop.Database.SqlServer.Module).Assembly);

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
               .AllowAnyMethod();
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

app.MapGet("users/me", async (ClaimsPrincipal claims, CoffeeSecurityDbContext context) =>
{
    string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

    return await context.Users.FindAsync(userId);
}).RequireAuthorization();

app.UseHttpsRedirection(); 
app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization(); 

app.UseEndpoints(endpoints => 
    {
        endpoints.MapControllers();
    }); 

app.CreateSecurityDbIfDoesNotExist(); 
app.CreateDbIfDoesNotExist();

app.MapIdentityApi<User>();

app.Run();