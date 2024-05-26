using Microsoft.EntityFrameworkCore;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Infrastructure.Database;

public class DataSeeder
{
    /// <summary>
    /// Seeds data for Role entity OnModelCreating in DbContext
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void SeedData(ModelBuilder modelBuilder)
    {
        var roles = new List<Role>
        {
            new Role(new Guid("4a4f1a6b-9c38-4a64-91f8-37008dd9a6b4"), "Beboer"),
            new Role(new Guid("5b5f2a7c-9d49-4b75-92f9-47019dd9b7c5"), "Menig"),
            new Role(new Guid("6c6f3a8d-9e50-4c86-93fa-57020dd9c8d6"), "Sekretær"),
            new Role(new Guid("7d7f4a9e-9f61-4d97-94fb-67031dd9d9e7"), "Kassér"),
            new Role(new Guid("8e8f5aaf-a072-4ea8-95fc-77042ddaead8"), "Næstformand"),
            new Role(new Guid("9f9f6ab0-b183-4fb9-96fd-87053ddbedf9"), "Formand")
        };

        modelBuilder.Entity<Role>().HasData(roles);
    }
}
