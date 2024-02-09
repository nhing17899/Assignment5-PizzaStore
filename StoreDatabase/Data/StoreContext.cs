using StoreDatabase.Entities;
using Microsoft.EntityFrameworkCore;
namespace StoreDatabase.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Pizza" },
                new Product { ProductId = 2, ProductName = "Beef" },
                new Product { ProductId = 3, ProductName = "Chicken" },
                new Product { ProductId = 4, ProductName = "Cheese" },
                new Product { ProductId = 5, ProductName = "Bacon" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Nhi" },
                new Customer { CustomerId = 2, FirstName = "Viet" },
                new Customer { CustomerId = 3, FirstName = "Elana" },
                new Customer { CustomerId = 4, FirstName = "Alyssa" },
                new Customer { CustomerId = 5, FirstName = "Joe" }
            ); ;
        }
    }
}
