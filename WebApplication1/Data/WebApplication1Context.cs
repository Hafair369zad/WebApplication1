using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<UserTb> Users { get; set; }
        public DbSet<CustomerTb> CustomerTbs { get; set; }
        public DbSet<OrderTb> OrderTbs { get; set; }
        public DbSet<ProductTb> ProductTbs { get; set; }
        public DbSet<OrderDetailTb> OrderDetailTbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relasi One-to-Many antara CustomerTb dan OrderTb
            modelBuilder.Entity<OrderTb>()
                .HasOne(o => o.Customer)                // Setiap Order memiliki satu Customer
                .WithMany(c => c.OrderTbs)              // Setiap Customer dapat memiliki banyak Order
                .HasForeignKey(o => o.CustomerId)       // ForeignKey yang menghubungkan CustomerId di OrderTb
                .OnDelete(DeleteBehavior.Cascade);      // Menghapus semua Order jika Customer dihapus

            // Menentukan composite key (gabungan dari OrderId dan ProductId) pada OrderDetailTb
            modelBuilder.Entity<OrderDetailTb>()
                .HasKey(od => new { od.OrderId, od.ProductId }); // Composite key

            // Relasi OrderDetailTb dan OrderTb
            modelBuilder.Entity<OrderDetailTb>()
                .HasOne(od => od.Order_OrderDetail)               // Relasi OrderDetail dan Order
                .WithMany(o => o.OrderDetailTbs)                  // Order memiliki banyak OrderDetail
                .HasForeignKey(od => od.OrderId)                  // Menetapkan ForeignKey
                .OnDelete(DeleteBehavior.Cascade);                // Cascade delete jika Order dihapus

            // Relasi OrderDetailTb dan ProductTb
            modelBuilder.Entity<OrderDetailTb>()
                .HasOne(od => od.Product_OrderDetail)             // Relasi OrderDetail dan Product
                .WithMany(p => p.OrderDetailTbs)                  // Product memiliki banyak OrderDetail
                .HasForeignKey(od => od.ProductId)                // Menetapkan ForeignKey
                .OnDelete(DeleteBehavior.Cascade);                // Cascade delete jika Product dihapus

            base.OnModelCreating(modelBuilder); // Pastikan ini dipanggil di akhir
        }
    }
}
