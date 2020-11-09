using LocalPizza.Core.Interfaces;
using LocalPizza.Core.Menu;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocalPizza.Data
{
    public class LocalPizzaContext : DbContext
    {
        public DbSet<MenuCategory> Menus { get; set; }
        public DbSet<ItemGroup> Groups { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        public LocalPizzaContext(DbContextOptions<LocalPizzaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaTopping>().HasKey(pt => new { pt.ItemId, pt.ToppingId });
        }
    }
}