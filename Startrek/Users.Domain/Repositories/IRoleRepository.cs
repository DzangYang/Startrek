using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface IRoleRepository
{
   public IEnumerable<Role> GetRoleByName(string roleName);
}