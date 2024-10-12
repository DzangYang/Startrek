using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface IPermissionRepository
{
   public IEnumerable<Permission> GetPermissionsByRoleName(int roleName);
   
}