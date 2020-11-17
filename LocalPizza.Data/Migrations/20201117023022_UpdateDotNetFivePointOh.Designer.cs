﻿// <auto-generated />
using System;
using LocalPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocalPizza.Data.Migrations
{
    [DbContext(typeof(LocalPizzaContext))]
    [Migration("20201117023022_UpdateDotNetFivePointOh")]
    partial class UpdateDotNetFivePointOh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LocalPizza.Core.Menu.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemGroupId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.ItemGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuCategoryId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.MenuCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.Item", b =>
                {
                    b.HasOne("LocalPizza.Core.Menu.ItemGroup", null)
                        .WithMany("Items")
                        .HasForeignKey("ItemGroupId");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.ItemGroup", b =>
                {
                    b.HasOne("LocalPizza.Core.Menu.MenuCategory", null)
                        .WithMany("ItemGroups")
                        .HasForeignKey("MenuCategoryId");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.Topping", b =>
                {
                    b.HasOne("LocalPizza.Core.Menu.Item", null)
                        .WithMany("ToppingsList")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.Item", b =>
                {
                    b.Navigation("ToppingsList");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.ItemGroup", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.MenuCategory", b =>
                {
                    b.Navigation("ItemGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
