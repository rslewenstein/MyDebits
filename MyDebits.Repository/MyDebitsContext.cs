using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyDebits.Domain;

namespace MyDebits.Repository
{
    public class MyDebitsContext : DbContext
    {
        public MyDebitsContext(DbContextOptions<MyDebitsContext> options) : base(options){}
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Debit>()
                .HasData(new List<Debit>(){
                    new Debit(1, "Conta de água", Convert.ToDateTime("05/07/2020"), 3528, 0),
                });

            builder.Entity<Category>()
                .HasData(new List<Category>(){
                    new Category(1, "Gastos Fixos"),
                });

            builder.Entity<PaymentMethod>()
                .HasData(new List<PaymentMethod>(){
                    new PaymentMethod(1, "Dinheiro"),
                });
        }
    }
}
