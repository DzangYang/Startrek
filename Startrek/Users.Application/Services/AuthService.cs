using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Users.Application.Abstractions;
using Users.Application.DTO.Requests;
using Users.Application.DTO.Responces;
using Users.Domain;
using Users.Domain.Repositories;

namespace Users.Application.Services;


public class AuthService(IPasswordHasher _passwordHasher, 
   IUserRepository _userRepository, 
   IJwtAuthService _jwtAuthService) : IAuthService
{
   public LoginUserResponce Login(LoginUserRequest request)
   {
      var user = _userRepository.GetByEmail(request.Email);

      var result = _passwordHasher.Verify(request.Password, user.PasswordHash);
      if (!result)
         throw new Exception("Ошибка");

      var token = _jwtAuthService.GenerateToken(user.Id,user.Email, user.PasswordHash);
    
      return new LoginUserResponce(token);

   }

  
   public RegisterUserResponce Register(RegisterUserRequest request)
   {
      var passHash = _passwordHasher.Generate(request.Password);
      var user = new User()
      {
         Id = Guid.NewGuid(),
         Email = request.Email,
         PasswordHash = passHash
      };
      
      _userRepository.Add(user);
      return new RegisterUserResponce(user.Id);

   }
}