using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Model;


namespace E_Commerce.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DataContext() : base("Data Source=OWAGEH-LT-11120\\SQLEXPRESS;Initial Catalog=ECommerce;Integrated Security=True;TrustServerCertificate=True")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<OrderDetails>().HasKey(OrderDetails => new { OrderDetails.OrderId, OrderDetails.ProductId });
            builder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("money");
            builder.Entity<OrderDetails>().Property(od => od.UnitPrice).HasColumnType("money");
            builder.Entity<Product>().Property(p => p.UnitPrice).HasColumnType("money");
            base.OnModelCreating(builder);
        }
        
    }
}
