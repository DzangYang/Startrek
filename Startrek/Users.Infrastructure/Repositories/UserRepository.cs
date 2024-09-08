using Microsoft.EntityFrameworkCore;
using Users.Domain;
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
   
   public ICollection<Permission> GetPermissionsUser(User user)
   {
      var permissions =  new List<Permission>();
      foreach (var role in user.Roles)
      {
         foreach (var permission in role.Permissions)
         {
            permissions.Add(permission);
         }
      }
      return permissions;
   }
   public ICollection<Role> GetRolesUser(User user)
   {
      var rolesUser = user.Roles.ToList();
      return rolesUser;
   }

   public User GetByEmail(string email)
   {
      var user = _context.Users.Include(r => r.Roles)
         .ThenInclude(x => x.Permissions)
         .FirstOrDefault(u => u.Email == email);

      
      return user;
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