using ToDo.API.Infrastructure.Middlewares;

namespace ToDo.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseCultureMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
