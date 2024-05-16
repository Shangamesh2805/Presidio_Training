using Microsoft.EntityFrameworkCore;
using PizzaStoreManagmentAPI.Models;

namespace PizzaStoreManagmentAPI.Context
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCredential> UserCredentials { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pizza>().HasData(

                new Pizza() { Id = 201, Name = "Pepperoni Pizza", size = "Large", price = 120, Availability = "In Stock" },
                new Pizza() { Id = 202, Name = "Veggie Pizza", size = "Medium", price = 80, Availability = "Out of Stock" },
                new Pizza() { Id = 203, Name = "BBQ Chicken Pizza", size = "Small", price = 90, Availability = "In Stock" }
                );

        }
    }
}
