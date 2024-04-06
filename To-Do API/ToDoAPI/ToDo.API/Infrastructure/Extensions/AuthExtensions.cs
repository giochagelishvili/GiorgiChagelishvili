using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ToDo.API.Infrastructure.Extensions
{
    public static class AuthExtensions
    {
        public static void AddTokenAuth(this IServiceCollection services, IConfiguration config)
        {
            var key = Encoding.ASCII.GetBytes(config.GetValue<string>("AuthConfiguration:SecretKey"));

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config.GetValue<string>("AuthConfiguration:Issuer"),
                    ValidAudience = config.GetValue<string>("AuthConfiguration:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
        }
    }
}
