using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnikProjekt.Web.Models;

namespace UnikProjekt.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<ApplicationUser> applicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedAdminUser(builder);
        }

        private void SeedAdminUser(ModelBuilder builder)
        {
            ApplicationUser adminUser = new ApplicationUser
            {
                UserName = "admin@admin.dk",
                Email = "admin@admin.dk",
                EmailConfirmed = false
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "12334");

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

            // Add user to database
            builder.Entity<ApplicationUser>().HasData(adminUser);

            // Assign admin role to superadmin user
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "9C99994C-621C-4717-A38B-08DC7D19E651",
                UserId = adminUser.Id
            });
        }

    }
}
