using Microsoft.AspNetCore.Builder;
using Shoepify.Infrastructure.CustomMiddlewares;

namespace Shoepify.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedRolesMiddleware>();
        }
    }
}
