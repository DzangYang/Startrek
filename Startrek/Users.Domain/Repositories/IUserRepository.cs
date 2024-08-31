namespace Users.Domain.Repositories;

public interface IUserRepository
{
   public void Add(User user);
   public User GetById();
   public User GetByEmail(string email);
}