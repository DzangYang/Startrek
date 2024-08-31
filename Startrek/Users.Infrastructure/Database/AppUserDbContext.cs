using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Microsoft.EntityFrameworkCore.Design.Internal;
using Users.Domain;

namespace Users.Infrastructure.Database;

public class AppUserDbContext : DbContext

{
   public DbSet<User> Users { get; set;  }
   
   public AppUserDbContext()
   {

   }

   public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options)
   {

   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.HasDefaultSchema("Users");
      base.OnModelCreating(modelBuilder);
   }
}
   