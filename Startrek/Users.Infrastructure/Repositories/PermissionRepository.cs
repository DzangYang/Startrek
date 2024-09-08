using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Domain.Repositories;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Repositories;

public class PermissionRepository(AppUserDbContext _context) : IPermissionRepository
{
   public IEnumerable<Permission> GetPermissionsByRoleName(int roleId)
   {
      var permissions =  _context.Permissions
         .Where(r => r.Id == roleId).ToList();
      return permissions;
   }
}  