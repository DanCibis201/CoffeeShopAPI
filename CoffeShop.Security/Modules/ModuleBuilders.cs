using CoffeeShop.Infrastructure.Core.DependencyInjection;
using CoffeeShop.Security.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CoffeeShop.Security.Modules;

public class ModuleBuilders : DependencyBuilderModule
{
    public override void Configure(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("users/me", async (ClaimsPrincipal claims, CoffeeSecurityDbContext context) =>
            {
                string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                return await context.Users.FindAsync(userId);
            }).RequireAuthorization();

            endpoints.MapPost("/logout", async (HttpContext httpContext) =>
            {
                await httpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                return Results.Ok("Logged out successfully.");
            }).RequireAuthorization();
        });
    }
}