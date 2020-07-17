﻿// <auto-generated />
using System;
using LocalPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocalPizza.Data.Migrations
{
    [DbContext(typeof(LocalPizzaContext))]
    partial class LocalPizzaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocalPizza.Core.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ItemId");

                    b.HasIndex("MenuTypeId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Description = "Huge pie cut into 8 extra-large slices. Authentic, soft & foldable New York-style dough, topped with Marinara pizza sauce & lots of stretchy mozzarella",
                            MenuTypeId = 1,
                            Name = "The Big Cheese",
                            Price = 15.1
                        },
                        new
                        {
                            ItemId = 2,
                            Description = "Huge pie cut into 8 extra-large slices. Authentic, soft & foldable New York-style dough, topped with Marinara pizza sauce & lots of crispy American pepperoni with hints of fennel & chilli",
                            MenuTypeId = 1,
                            Name = "The Big Pepperoni",
                            Price = 17.5
                        },
                        new
                        {
                            ItemId = 3,
                            Description = "Succulent chicken, crispy rasher bacon, spinach and red onion, topped with a creamy ranch sauce and served on a pizza sauce base with zesty garlic sauce",
                            MenuTypeId = 1,
                            Name = "Garlic Chicken & Bacon Ranch",
                            Price = 12.5
                        },
                        new
                        {
                            ItemId = 4,
                            Description = "The perfect combination of succulent chicken pieces, crispy rasher bacon & slices of red onion on a BBQ sauce base",
                            MenuTypeId = 1,
                            Name = "Bbq Chicken & Rasher Bacon",
                            Price = 12.6
                        },
                        new
                        {
                            ItemId = 5,
                            Description = "Juicy prawns, paired with fresh baby spinach & diced tomato on a crème fraiche & zesty garlic sauce base, topped with oregano",
                            MenuTypeId = 1,
                            Name = "Garlic Prawn",
                            Price = 12.699999999999999
                        },
                        new
                        {
                            ItemId = 6,
                            Description = "Dipping Sauce",
                            MenuTypeId = 2,
                            Name = "Ranch Dipping Sauce",
                            Price = 0.5
                        },
                        new
                        {
                            ItemId = 7,
                            Description = "Oven baked chips dusted with chicken salt",
                            MenuTypeId = 2,
                            Name = "Oven Baked Chips",
                            Price = 5.5
                        },
                        new
                        {
                            ItemId = 8,
                            Description = "Freshly oven baked herb & garlic bread, topped with stretchy mozzarella",
                            MenuTypeId = 2,
                            Name = "Cheesy Garlic Bread",
                            Price = 8.9000000000000004
                        },
                        new
                        {
                            ItemId = 9,
                            Description = "A classic vanilla sundae drizzled with salted caramel sauce",
                            MenuTypeId = 3,
                            Name = "Salted Caramel Sundae",
                            Price = 2.9500000000000002
                        },
                        new
                        {
                            ItemId = 10,
                            Description = "A classic vanilla sundae drizzled with decadent chocolate sauce",
                            MenuTypeId = 3,
                            Name = "2 Choc Sundaes",
                            Price = 5.0999999999999996
                        },
                        new
                        {
                            ItemId = 11,
                            Description = "1.25L",
                            MenuTypeId = 4,
                            Name = "Pepsi",
                            Price = 4.9000000000000004
                        });
                });

            modelBuilder.Entity("LocalPizza.Core.Entities.MenuType", b =>
                {
                    b.Property<int>("MenuTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuTypeId");

                    b.ToTable("MenuTypes");

                    b.HasData(
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
                        });
                });

            modelBuilder.Entity("LocalPizza.Core.Entities.Item", b =>
                {
                    b.HasOne("LocalPizza.Core.Entities.MenuType", "MenuType")
                        .WithMany()
                        .HasForeignKey("MenuTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
