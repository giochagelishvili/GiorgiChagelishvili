using PizzaProject.API.Infrastructure.Middlewares;

namespace PizzaProject.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseCultureMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
