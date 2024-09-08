using System.ComponentModel.DataAnnotations;

namespace Users.Domain.Entities; 
public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash{ get; set; } = string.Empty;
    public ICollection<Role> Roles { get; set; } = new List<Role>();
   
}
