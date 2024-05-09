using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database.EntityConfiguration;

namespace UnikProjekt.Infrastructure.Database;

public class UnikDbContext : DbContext
{
    public UnikDbContext(DbContextOptions<UnikDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    //TODO: HUSK at tilføje DBSets!!!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // TODO: HUSK at tilføje ApplyConfiguration for hver configuration!!
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}