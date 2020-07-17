using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocalPizza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Data
{
    public class LocalPizzaContext : DbContext
    {
        public LocalPizzaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Item>().HasData(
                new
                {
                    ItemId = 1,
                    Name = "The Big Cheese",
                    Description = "Huge pie cut into 8 extra-large slices. Authentic, soft & foldable New York-style dough, topped with Marinara pizza sauce & lots of stretchy mozzarella",
                    Price = 15.1,
                    MenuTypeId = 1
                },
                new
                {
                    ItemId = 2,
                    Name = "The Big Pepperoni",
                    Description = "Huge pie cut into 8 extra-large slices. Authentic, soft & foldable New York-style dough, topped with Marinara pizza sauce & lots of crispy American pepperoni with hints of fennel & chilli",
                    Price = 17.5,
                    MenuTypeId = 1
                },
                new
                {
                    ItemId = 3,
                    Name = "Garlic Chicken & Bacon Ranch",
                    Description = "Succulent chicken, crispy rasher bacon, spinach and red onion, topped with a creamy ranch sauce and served on a pizza sauce base with zesty garlic sauce",
                    Price = 12.5,
                    MenuTypeId = 1
                },
                new
                {
                    ItemId = 4,
                    Name = "Bbq Chicken & Rasher Bacon",
                    Description = "The perfect combination of succulent chicken pieces, crispy rasher bacon & slices of red onion on a BBQ sauce base",
                    Price = 12.6,
                    MenuTypeId = 1
                },
                new
                {
                    ItemId = 5,
                    Name = "Garlic Prawn",
                    Description = "Juicy prawns, paired with fresh baby spinach & diced tomato on a crème fraiche & zesty garlic sauce base, topped with oregano",
                    Price = 12.7,
                    MenuTypeId = 1
                },
                new
                {
                    ItemId = 6,
                    Name = "Ranch Dipping Sauce",
                    Description = "Dipping Sauce",
                    Price = 0.5,
                    MenuTypeId = 2
                },
                new
                {
                    ItemId = 7,
                    Name = "Oven Baked Chips",
                    Description = "Oven baked chips dusted with chicken salt",
                    Price = 5.5,
                    MenuTypeId = 2
                },
                new
                {
                    ItemId = 8,
                    Name = "Cheesy Garlic Bread",
                    Description = "Freshly oven baked herb & garlic bread, topped with stretchy mozzarella",
                    Price = 8.9,
                    MenuTypeId = 2
                },
                new
                {
                    ItemId = 9,
                    Name = "Salted Caramel Sundae",
                    Description = "A classic vanilla sundae drizzled with salted caramel sauce",
                    Price = 2.95,
                    MenuTypeId = 3
                },
                new
                {
                    ItemId = 10,
                    Name = "2 Choc Sundaes",
                    Description = "A classic vanilla sundae drizzled with decadent chocolate sauce",
                    Price = 5.1,
                    MenuTypeId = 3
                },
                new
                {
                    ItemId = 11,
                    Name = "Pepsi",
                    Description = "1.25L",
                    Price = 4.9,
                    MenuTypeId = 4
                }

            );

            bldr.Entity<MenuType>().HasData(
                new
                {
                    MenuTypeId = 1,
                    Name = "Pizza"
                },
                new
                {
                    MenuTypeId = 2,
                    Name = "Side"
                },
                new
                {
                    MenuTypeId = 3,
                    Name = "Dessert"
                },
                new
                {
                    MenuTypeId = 4,
                    Name = "Drink"
                }
            );
        }
    }
}
