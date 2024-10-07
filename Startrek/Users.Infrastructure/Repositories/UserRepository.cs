using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Repositories;
using Users.Infrastructure.Database;


namespace Users.Infrastructure.Repositories;

public class UserRepository(AppUserDbContext _context) : IUserRepository
{
   public User GetById()
   {
      throw new NotImplementedException();
   }

   public void ApplyPermission(User user)
   {
     
   }
   
   public ICollection<Permission>? GetPermissionsUser(User user)
   {
      var permissions = user.Roles.SelectMany(ar => ar.Permissions);
   
      return permissions.ToArray();
   }
   public ICollection<Role>? GetRolesUser(User user)
   {
      var rolesUser = user.Roles.ToList();
      return rolesUser;
   }

   public User? GetByEmail(string email)
   {
      var existUser = _context.Users.
         Include(r => r.Roles)
         .ThenInclude(x => x.Permissions)
         .FirstOrDefault(u => u.Email == email);
      
      return existUser;
   }

   public IEnumerable<User> GetAll()
   {
      return _context.Users.ToList();
   }
   
   public void Add(User user)
   {
      _context.Users.Add(user);
      _context.SaveChanges();
   }
}