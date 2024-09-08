using Users.Application.DTO.Requests;
using Users.Application.DTO.Responces;
using Users.Domain;
using Users.Domain.Entities;


namespace Users.Application.Abstractions;

public interface IAuthService
{
   public RegisterUserResponce Register(RegisterUserRequest request);
   public LoginUserResponce Login(LoginUserRequest request);
   public IEnumerable<User> GetAll();
   /*public ICollection<Role> GetRolesUser(User user);
   public ICollection<Permission> GetPermissionsUser(User user);*/

}