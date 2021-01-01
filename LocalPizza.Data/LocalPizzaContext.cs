
using LocalPizza.Core.Menu;
using LocalPizza.Core.Orders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocalPizza.Data
{
    public class LocalPizzaContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public LocalPizzaContext(DbContextOptions<LocalPizzaContext> options) : base(options)
        {
        }
    }
}