using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Application.Exceptions;

namespace ToDo.API.Infrastructure.Auth
{
    public static class JwtHelper
    {
        public static string GenerateToken(string userName, string id, IOptions<AuthConfiguration> options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(options.Value.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("UserName", userName),
                new Claim("Id", id)
            }),
                Issuer = options.Value.Issuer,
                Audience = options.Value.Audience,
                Expires = DateTime.UtcNow.AddMinutes(options.Value.ExpInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
