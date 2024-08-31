using Users.Application.Abstractions;

namespace Users.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
   public string Generate(string password)
   {
      var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
      return passwordHash;
   }

   public bool Verify(string password, string hashedPassword)
   {
      var validateHashPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
      return validateHashPassword;
   }
}