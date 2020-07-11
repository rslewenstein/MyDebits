﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDebits.Repository;

namespace MyDebits.Repository.Migrations
{
    [DbContext(typeof(MyDebitsContext))]
    partial class MyDebitsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("MyDebits.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Gastos Fixos"
                        });
                });

            modelBuilder.Entity("MyDebits.Domain.Debit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateDebit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DebitValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Quota")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Debits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateDebit = new DateTime(2020, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebitValue = 3528m,
                            Description = "Conta de água",
                            PaymentMethodId = 1,
                            Quota = 0
                        });
                });

            modelBuilder.Entity("MyDebits.Domain.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dinheiro"
                        });
                });

            modelBuilder.Entity("MyDebits.Domain.Debit", b =>
                {
                    b.HasOne("MyDebits.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("MyDebits.Domain.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId");
                });
#pragma warning restore 612, 618
        }
    }
}
