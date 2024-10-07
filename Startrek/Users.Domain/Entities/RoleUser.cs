namespace Users.Domain.Entities;

public class RoleUser
{
   public Guid MemberId { get; set; }
   public int RoleId { get; set; }
   public User Member { get; set; }
   public Role Role { get; set; }
}