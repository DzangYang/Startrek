using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;
using Users.Infrastructure.Database;

using Permission = Users.Domain.Enums.Permission;
using PermissionClass = Users.Domain.Entities.Permission;

namespace Users.Infrastructure.Auth;

public  sealed class RolePermissionConfiguration() : IEntityTypeConfiguration<RolePermission>
{
   public void Configure(EntityTypeBuilder<RolePermission> builder)
   {
      builder.ToTable("RolePermission");
      
      builder.HasIndex(x => new { x.RoleId, x.PermissionId }).IsUnique();


      builder.HasKey(x => new { x.RoleId, x.PermissionId });

   
      
      builder.HasData(
         Create(Role.Administator, Permission.AccessMember),
         Create(Role.Administator, Permission.ReadMember),
         Create(Role.Registered, Permission.ReadMember),
         Create(Role.Manager, Permission.AccessMember)
         );
   }

   private static RolePermission Create(Role role, Permission permission)
   {
    
      return new RolePermission
      {
         RoleId = role.Id,
         PermissionId = (int)permission
      };
   }
}