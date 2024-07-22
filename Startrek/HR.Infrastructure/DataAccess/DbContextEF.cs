using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HR.Infrastructure.DataAccess;
public class DbContextEF : DbContext
{
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }

    public DbContextEF()
    {
       
    }
    public DbContextEF(DbContextOptions<DbContextEF> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
