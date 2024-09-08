using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;
using Users.Domain.Primitives;

namespace Users.Infrastructure.Auth;

public  sealed class PermissionConfiguration : IEntityTypeConfiguration<Users.Domain.Entities.Permission>
{
   public void Configure(EntityTypeBuilder<Permission> builder)
   {
      builder.ToTable("Permission");

      builder.HasKey(x => x.Id);

      builder.HasIndex(x => x.Id).IsUnique();

      IEnumerable<Permission> permissions = Enum.GetValues<Users.Domain.Enums.Permission>()
         .Select(p => new Permission
         {
            Id = (int)p,
            Name = p.ToString()
         });

      builder.HasData(permissions);
   }
}