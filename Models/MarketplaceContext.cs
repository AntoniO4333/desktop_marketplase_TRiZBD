using Microsoft.EntityFrameworkCore;
using web_marketplase_TRiZBD.Models;
using static web_marketplase_TRiZBD.Models.Classes;  // Подключение пространства имен, где определены ваши модели

namespace web_marketplase_TRiZBD.Models
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseEmployee> WarehouseEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=CHEREMUSHKINPC\\SQLEXPRESS;initial catalog=MP_4_TRiZBD;integrated security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Для OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.ProductID });

            // Для WarehouseEmployee
            modelBuilder.Entity<WarehouseEmployee>()
                .HasKey(we => new { we.WarehouseID, we.UserID }); // Указание составного ключа
        }


    }
}
