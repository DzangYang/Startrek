using Users.Application.Abstractions;
using Users.Application.DTO.Requests;
using Users.Application.DTO.Responces;
using Users.Domain.Entities;
using Users.Domain.Repositories;

namespace Users.Application.Services;


public class AuthService(IPasswordHasher _passwordHasher, 
   IUserRepository _userRepository, 
   IJwtAuthService _jwtAuthService, 
   IRoleRepository _roleRepository, 
   IPermissionRepository _permissionRepository) : IAuthService
{
    
   public LoginUserResponce Login(LoginUserRequest request)
   {
      var user = _userRepository.GetByEmail(request.Email);
      if (user is null)
         throw new Exception("Пользователя не существует");

      var result = _passwordHasher.Verify(request.Password, user.PasswordHash);
      if (!result)
         throw new Exception("Ошибка верификации пароля");
      
      var token = _jwtAuthService.GenerateToken(user);
    
      return new LoginUserResponce(token);
   }

   public IEnumerable<User> GetAll()
   {
     var users =  _userRepository.GetAll();
     return users;
   }

   public RegisterUserResponce Register(RegisterUserRequest request)
   {
      var passHash = _passwordHasher.Generate(request.Password);
      
      var user = new User()
      {
         Id = Guid.NewGuid(),
         Email = request.Email,
         PasswordHash = passHash,
      };

      var roles = _roleRepository.GetRoleByName(request.RoleName);
      
      foreach (var role in roles)
         user.Roles.Add(role);
      
      _userRepository.Add(user);
      return new RegisterUserResponce(user.Id);

   }



}
