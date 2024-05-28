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
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingLine> BookingLines { get; set; }
    public DbSet<BookingItem> BookingItems { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new BookingLineConfiguration());
        modelBuilder.ApplyConfiguration(new BookingItemConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());

        //Calls the SeedData method in DataSeeder (for Roles seeding)
        DataSeeder.SeedData(modelBuilder);
    }
}