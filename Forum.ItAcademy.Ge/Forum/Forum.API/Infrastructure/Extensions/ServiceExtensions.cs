using Forum.Shared.Extensions;

namespace Forum.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomHealthChecks(this IServiceCollection services, IConfiguration config)
        {
            var host = config.GetValue<string>("Constants:Host");
            services.AddCommonHealthChecks(config)
                .AddUrlGroup(new Uri($"{host}/api/topic"), "Topics Endpoint");
        }
    }
}