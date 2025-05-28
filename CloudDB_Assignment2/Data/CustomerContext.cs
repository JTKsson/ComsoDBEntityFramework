using CloudDB_Assignment2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudDB_Assignment2.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToContainer("Customers")
                .HasPartitionKey(c => c.CustomerId);
        }

    }
}
