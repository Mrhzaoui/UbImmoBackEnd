using Microsoft.EntityFrameworkCore;
using UBEE.Models;

namespace UBEE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AIEvaluation> AIEvaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships
            modelBuilder.Entity<Property>()
                .HasOne(p => p.User)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Optional: Delete cascade if needed

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Property)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);  // Optional: Delete cascade if needed

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Buyer)
                .WithMany() // This is correct, since Transaction has only one Buyer and Seller
                .HasForeignKey(t => t.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);  // Ensures no cascade delete

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Seller)
                .WithMany()
                .HasForeignKey(t => t.SellerId)
                .OnDelete(DeleteBehavior.Restrict);  // Ensures no cascade delete

            modelBuilder.Entity<AIEvaluation>()
                .HasOne(a => a.Property)
                .WithOne(p => p.AIEvaluation)
                .HasForeignKey<AIEvaluation>(a => a.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);  // Optional: Delete cascade if needed

            // Configure decimal properties with precision and scale
            modelBuilder.Entity<AIEvaluation>()
                .Property(a => a.EstimatedValue)
                .HasPrecision(18, 4); // Precision: 18, Scale: 4

            modelBuilder.Entity<Property>()
                .Property(p => p.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 4);
        }
    }
}
