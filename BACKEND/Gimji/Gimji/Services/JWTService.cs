using Gimji.Models;
using Gimji.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gimji.Services
{
    public class JWTService : JWTRepository
    {
        private IConfiguration _config;
        public JWTService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateTokenAccount(employee employee, DateTime expireTime)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(secretKeyBytes, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {
                new Claim("Username", employee.accountId),
                new Claim(ClaimTypes.Email, employee.email),
                new Claim(ClaimTypes.Sid, employee.id.ToString())
            };
            foreach (var role in employee.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.roleName));
            }

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: expireTime,
              signingCredentials: credentials
            );

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
