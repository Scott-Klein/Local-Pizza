using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocalPizza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LocalPizza.Core.Interfaces;
using LocalPizza.Core.Menu;

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
