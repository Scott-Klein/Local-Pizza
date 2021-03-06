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
    [Migration("20210101070701_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
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

                    b.Property<string>("ProductPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("LocalPizza.Core.Orders.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("LocalPizza.Core.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveredTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LocalPizza.Core.Orders.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Base")
                        .HasColumnType("int");

                    b.Property<int>("Crust")
                        .HasColumnType("int");

                    b.Property<bool>("IsPizza")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OrderItemTopping", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingsId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemsId", "ToppingsId");

                    b.HasIndex("ToppingsId");

                    b.ToTable("OrderItemTopping");
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

            modelBuilder.Entity("LocalPizza.Core.Orders.Order", b =>
                {
                    b.HasOne("LocalPizza.Core.Orders.Address", "DeliveryAddress")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryAddressId");

                    b.Navigation("DeliveryAddress");
                });

            modelBuilder.Entity("LocalPizza.Core.Orders.OrderItem", b =>
                {
                    b.HasOne("LocalPizza.Core.Menu.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId");

                    b.HasOne("LocalPizza.Core.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderItemTopping", b =>
                {
                    b.HasOne("LocalPizza.Core.Orders.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalPizza.Core.Menu.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocalPizza.Core.Menu.Item", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("LocalPizza.Core.Orders.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("LocalPizza.Core.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
