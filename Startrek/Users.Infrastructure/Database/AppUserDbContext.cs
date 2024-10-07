using Microsoft.EntityFrameworkCore;
using Startrek.Server.Auth;
using Users.Domain.Entities;
using Users.Infrastructure.Auth;

namespace Users.Infrastructure.Database;

public class AppUserDbContext : DbContext

{
   public DbSet<User> Users { get; set;  }
   public DbSet<Role> Roles { get; set; }
   public DbSet<Permission> Permissions { get; set; }
   public DbSet<RolePermission> RolePermissions { get; set; }
   public AppUserDbContext()
   {

   }

   public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options)
   {

   }
   
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
    
      modelBuilder.HasDefaultSchema("Users");
      /*modelBuilder.Entity<RoleUser>().HasOne<User>(x =>x.Member).WithMany().HasForeignKey(x => x.MemberId);
      modelBuilder.Entity<RoleUser>().HasOne<Role>(x =>x.Role).WithMany().HasForeignKey(x => x.RoleId);*/
      modelBuilder.ApplyConfiguration(new RoleConfiguration());
      modelBuilder.ApplyConfiguration(new PermissionConfiguration());
      modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
    
   }
}
   