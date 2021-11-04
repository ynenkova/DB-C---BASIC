using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-EJ1MT1A4;Database=SalesDatabase;Integrated Security=true");
            }
        }
        
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.Property(x => x.Name).IsUnicode();
                product.Property(x => x.Description)
                .HasDefaultValue("No description");
            });
            modelBuilder.Entity<Customer>(customer =>
            {
                customer.Property(x => x.Name).IsUnicode();
                customer.Property(x => x.Email).IsUnicode(false);
            });
            modelBuilder.Entity<Store>(store =>
            {
                store.Property(x => x.Name).IsUnicode();
            });
            modelBuilder.Entity<Sale>(sale =>
            {
                sale.Property(x => x.Date).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<Sale>(sales =>
            {
                sales.HasOne(x => x.Product)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.ProductId);

                sales.HasOne(x => x.Customer)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId);

                sales.HasOne(x => x.Store)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.StoreId);
            });
        }
    }
}
