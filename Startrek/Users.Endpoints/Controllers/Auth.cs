using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Users.Application.Abstractions;
using Users.Application.DTO.Requests;

namespace Users.Endpoints.Controllers;


[ApiController]
[Route("[controller]")]
public class Auth(IAuthService authService, IHttpContextAccessor contextAccessor) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterUserRequest request)
    {
        var result = authService.Register(request);
        return Ok(result);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUserRequest request)
    {
        var result = authService.Login(request);
       
        
        return Ok(result);
    }
  
}