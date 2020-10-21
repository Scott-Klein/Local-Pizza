using LocalPizza.Core.Menu;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalPizza.Data
{
    public class LocalPizzaContext : IdentityDbContext
    {
        public DbSet<MenuCategory> Menus { get; set; }
        public DbSet<ItemGroup> Groups { get; set; }
        public DbSet<Item> Items { get; set; }

        public LocalPizzaContext(DbContextOptions options) : base(options)
        {
        }
    }
}