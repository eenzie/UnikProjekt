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

    //HUSK at tilføje DBSets!!!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}