using Users.Domain.Entities;

namespace Users.Application.Abstractions;

public interface IJwtAuthService
{
   public string GenerateToken(User user);
}