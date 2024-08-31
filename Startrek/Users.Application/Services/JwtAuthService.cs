using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Users.Application.Abstractions;

namespace Users.Application.Services;

public class JwtAuthService(IConfiguration _configuration) : IJwtAuthService
{
   public string GenerateToken(Guid id, string email, string passwordHash)
   {
      var claims = new List<Claim>
      {
         new Claim("iss","http://localhost:5111"),
         new Claim("aud","http://localhost:5111"),
         new Claim(("userId"), id.ToString()),
         new Claim(ClaimTypes.Email, email)
      };
         

      var signingCredentials = new SigningCredentials(
         new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("JwtTokenSettings:SecretKey").Value)),
         SecurityAlgorithms.HmacSha256);


      var token = new JwtSecurityToken(
         signingCredentials: signingCredentials,
         claims: claims,
         expires: DateTime.UtcNow.AddHours(2)
      );

      var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
      return jwtToken;
   }
}