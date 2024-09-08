using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Users.Application;
using Users.Application.Abstractions;
using Users.Application.DTO.Requests;
using Users.Domain.Enums;

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
    
    [Authorize(Policy = "AccesMember")]
    [HttpGet("fgdfg")]
    public IActionResult GetMemberData()
    {
        return Ok("Access granted for AccessMember");
    }

    [HttpGet]
    [HasPermission(Permission.AccessMember)]
    public IActionResult GetAll()
    {
        var result =  authService.GetAll().ToList();
        return Ok(result);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginUserRequest request)
    {
        var result = authService.Login(request);
       
        
        return Ok(result);
    }
  
}