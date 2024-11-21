using CoffeeShop.Infrastructure.Core.DependencyInjection;
using CoffeeShop.Security.Context;
using CoffeeShop.Security.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Security.Modules;

public class ModuleServices : DependencyModule
{
    public override void Load(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        })
        .AddCookie(IdentityConstants.ApplicationScheme)
        .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<CoffeeSecurityDbContext>()
            .AddApiEndpoints();

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });
    }
}