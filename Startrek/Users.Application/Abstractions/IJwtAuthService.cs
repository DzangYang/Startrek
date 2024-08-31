namespace Users.Application.Abstractions;

public interface IJwtAuthService
{
   public string GenerateToken(Guid id, string email, string passwordHash);
}