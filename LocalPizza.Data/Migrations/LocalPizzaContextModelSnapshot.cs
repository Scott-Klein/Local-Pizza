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
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ItemTopping", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingsListId")
                        .HasColumnType("int");

                    b.HasKey("ItemsId", "ToppingsListId");

                    b.HasIndex("ToppingsListId");

                    b.ToTable("ItemTopping");
                });

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("ItemTopping", b =>
                {
                    b.HasOne("LocalPizza.Core.Menu.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalPizza.Core.Menu.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
