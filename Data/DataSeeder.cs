using Microsoft.EntityFrameworkCore;
using UBEE.Models;

namespace UBEE.Data
{
    public static class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check if the database already contains data
                if (context.Users.Any() || context.Properties.Any() || context.Services.Any())
                {
                    return;   // Database has been seeded
                }

                // Seed Users
                context.Users.AddRange(
                    new User { Name = "John Doe", Email = "john@example.com", PasswordHash = "hashedpassword", Role = "PropertyOwner" },
                    new User { Name = "Jane Smith", Email = "jane@example.com", PasswordHash = "hashedpassword", Role = "Buyer" }
                );

                // Seed Properties
                context.Properties.AddRange(
                    new Property { Address = "123 Main St", Price = 250000, Description = "Beautiful 3 bedroom house" },
                    new Property { Address = "456 Elm St", Price = 180000, Description = "Cozy 2 bedroom apartment" }
                );

                // Seed Services
                context.Services.AddRange(
                    new Service { Name = "Legal Consultation", Description = "1-hour legal consultation", Price = 150, Category = "Legal" },
                    new Service { Name = "Property Photography", Description = "Professional photo shoot of your property", Price = 200, Category = "Photography" }
                );

                context.SaveChanges();
            }
        }
    }
}


