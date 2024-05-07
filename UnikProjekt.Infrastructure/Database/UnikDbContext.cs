using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnikProjekt.Domain.Entities;

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

        //TODO: HJÆLP til seed database med records (complext properties)
        //modelBuilder.Entity<User>()
        //    .HasData(
        //    new User(Guid.NewGuid(), new EmailAddress("test@test.com"), new Name("Test", "Tester"), new MobileNumber("88888888")));
    }
}