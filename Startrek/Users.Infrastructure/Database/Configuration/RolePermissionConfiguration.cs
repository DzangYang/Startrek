using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;
using Permission = Shared.Core.Permission;

namespace Users.Infrastructure.Auth;

public  sealed class RolePermissionConfiguration() : IEntityTypeConfiguration<RolePermission>
{
   public void Configure(EntityTypeBuilder<RolePermission> builder)
   {
      builder.ToTable("RolePermission");
      
      builder.HasIndex(x => new { x.RoleId, x.PermissionId }).IsUnique();

      builder.HasKey(x => new { x.RoleId, x.PermissionId });
      
      builder.HasData(
         Create(Role.Administator, Permission.DeletionMember),
         Create(Role.Administator, Permission.TaskMember),
         Create(Role.Administator, Permission.UpdateMember),
         Create(Role.HR_Officer, Permission.TaskMember),
         Create(Role.HR_Officer, Permission.UpdateMember),
         Create(Role.HR_Officer, Permission.DeletionMember),
         Create(Role.HR_Officer, Permission.HR_AddCandidates),
         Create(Role.HR_Officer, Permission.HR_AddInterview),
         Create(Role.HR_Officer, Permission.HR_AddOffer),
         Create(Role.HR_Officer, Permission.HR_AddVacancy)
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