using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Startrek.Server.Auth;

public  sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
   public void Configure(EntityTypeBuilder<Role> builder)
   {
      builder.ToTable("Role");
      builder.HasIndex(x => x.Id).IsUnique();
      
      builder.HasKey(x => x.Id);

      builder.HasMany(x => x.Permissions)
         .WithMany()
         .UsingEntity<RolePermission>(
            r => r.HasOne<Permission>(x => x.Permission).WithMany().HasForeignKey(x => x.PermissionId),
            r => r.HasOne<Role>(x => x.Role).WithMany().HasForeignKey(x => x.RoleId)
            );
      

      builder.HasMany(x => x.Members).WithMany(x => x.Roles)
         .UsingEntity<RoleUser>(
            ur => ur.HasOne<User>(x => x.Member).WithMany().HasForeignKey(x => x.MemberId),
         ur => ur.HasOne<Role>(x => x.Role).WithMany().HasForeignKey(r => r.RoleId)
            );

      builder.HasData(Role.GetValues());
   }
}