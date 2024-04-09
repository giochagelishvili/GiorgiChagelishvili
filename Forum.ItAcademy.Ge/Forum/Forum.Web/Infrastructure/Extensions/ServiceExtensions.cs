using Forum.Application.Profiles;
using Forum.Application.Profiles.Interfaces;

namespace Forum.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
