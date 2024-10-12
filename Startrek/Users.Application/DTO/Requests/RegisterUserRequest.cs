namespace Users.Application.DTO.Requests;

public sealed  record RegisterUserRequest(string Email, string Password, string RoleName, int Id);