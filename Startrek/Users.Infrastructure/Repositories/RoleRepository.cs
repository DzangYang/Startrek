using Users.Domain.Entities;
using Users.Domain.Repositories;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Repositories;

public class RoleRepository(AppUserDbContext _context)  : IRoleRepository
{
   public IEnumerable<Role> GetRoleByName(string roleName)
   {
      var roles = _context.Roles
         .Where(r => r.Name == roleName).ToList();
      return roles;
   }
}