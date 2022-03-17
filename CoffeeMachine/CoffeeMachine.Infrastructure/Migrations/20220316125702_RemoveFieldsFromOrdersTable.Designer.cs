﻿// <auto-generated />
using System;
using CoffeeMachine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoffeeMachine.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220316125702_RemoveFieldsFromOrdersTable")]
    partial class RemoveFieldsFromOrdersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoffeeMachine.Core.Models.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Coffee");
                });

            modelBuilder.Entity("CoffeeMachine.Core.Models.MachineBanknote", b =>
                {
                    b.Property<int>("Denomination")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Denomination"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("Denomination");

                    b.ToTable("MachineBanknotes");
                });

            modelBuilder.Entity("CoffeeMachine.Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TotalCost")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CoffeeMachine.Core.Models.OrderCoffee", b =>
                {
                    b.Property<int>("CoffeeId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("CoffeeId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrdersCoffee");
                });

            modelBuilder.Entity("CoffeeMachine.Core.Models.OrderCoffee", b =>
                {
                    b.HasOne("CoffeeMachine.Core.Models.Coffee", "Coffee")
                        .WithMany("OrderCoffee")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeMachine.Core.Models.Order", "Order")
                        .WithMany("OrderCoffee")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CoffeeMachine.Core.Models.Coffee", b =>
                {
                    b.Navigation("OrderCoffee");
                });

            modelBuilder.Entity("CoffeeMachine.Core.Models.Order", b =>
                {
                    b.Navigation("OrderCoffee");
                });
#pragma warning restore 612, 618
        }
    }
}
