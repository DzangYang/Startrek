using Users.Domain;
using Users.Domain.Repositories;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Repositories;

public class UserRepository(AppUserDbContext _context) : IUserRepository
{
   public User GetById()
   {
      throw new NotImplementedException();
   }

   public User GetByEmail(string email)
   {
      var user = _context.Users.FirstOrDefault(u => u.Email == email);
      return user;
   }

   public void Add(User user)
   {
      _context.Users.Add(user);
      _context.SaveChanges();
   }
}