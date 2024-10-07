using Users.Domain.Primitives;

namespace Users.Domain.Entities;

public class Role : Enumeration<Role>
{
   public static readonly Role Administator = new (1, "Admininstrator");
   public static readonly Role HR_Officer = new (2, "HR_Officer");
   public static readonly Role Manager = new(3, "Manager");
   public static readonly Role HR_Manager = new(4, "HR_Manager");

   public Role(int id, string name) 
   : base(id, name)
   {
   }

   /// <summary>
   /// Разрешения доступные для роли
   /// </summary>
   public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

   /// <summary>
   /// Список участников роли
   /// </summary>
   public ICollection<User> Members { get; set; } = new List<User>();
}