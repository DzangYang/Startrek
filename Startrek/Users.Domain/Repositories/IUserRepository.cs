using Users.Domain.Entities;

namespace Users.Domain.Repositories;

public interface IUserRepository
{
   public void Add(User user);
   
   public User GetById();
   public User GetByEmail(string email);
   public IEnumerable<User> GetAll();
   public void ApplyPermission(User user);
   public ICollection<Permission> GetPermissionsUser(User user);
   public ICollection<Role> GetRolesUser(User user);
}