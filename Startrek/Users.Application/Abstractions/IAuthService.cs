using Users.Application.DTO.Requests;
using Users.Application.DTO.Responces;

namespace Users.Application.Abstractions;

public interface IAuthService
{
   public RegisterUserResponce Register(RegisterUserRequest request);
   public LoginUserResponce Login(LoginUserRequest request);
  
}