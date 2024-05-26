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

    //TODO: HUSK at tilføje DBSets!!!
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // TODO: HUSK at tilføje ApplyConfiguration for hver configuration!!
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        //Calls the SeedData method in DataSeeder (for Roles seeding)
        DataSeeder.SeedData(modelBuilder);
    }
}