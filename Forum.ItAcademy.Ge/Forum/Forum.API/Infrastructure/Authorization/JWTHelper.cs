using Forum.Domain.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forum.API.Infrastructure.Authorization
{
    public static class JWTHelper
    {
        public static string GenerateToken(User user, IConfiguration config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AuthConfiguration:SecretKey"]));

            var issuer = config["AuthConfiguration:Issuer"];
            var audience = config["AuthConfiguration:Audience"];
            var exp = double.Parse(config["AuthConfiguration:ExpInMinutes"]);

            var claims = new Claim[]
            {
                new("Username", user.UserName),
                new("Id", user.Id)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddMinutes(exp), signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
