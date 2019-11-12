using Acme.SalesImporter.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.SalesImporter.Db.MySql
{
    public static class EntityMapper
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreOrder>(entity =>
            {
                entity.ToTable("STORE_ORDER");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired();
                entity.Property(e => e.OrderDate)
                    .HasColumnName("ORDER_DATE")
                    .HasColumnType("DATE")
                    .IsRequired();
                entity.Property(e => e.ShipDate)
                    .HasColumnName("SHIP_DATE")
                    .HasColumnType("DATE")
                    .IsRequired();
                entity.Property(e => e.ShipMode)
                    .HasColumnName("SHIP_MODE")
                    .HasColumnType("VARCHAR(20)");
                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("INT")
                    .IsRequired();
                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("DECIMAL(3,2)");
                entity.Property(e => e.Profit)
                    .HasColumnName("PROFIT")
                    .HasColumnType("DECIMAL(6,2)");
                entity.Property(e => e.ProductId)
                    .HasColumnName("PRODUCT_ID")
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired();
                entity.Property(e => e.CustomerName)
                    .HasColumnName("CUSTOMER_NAME")
                    .HasColumnType("VARCHAR(255)")
                    .IsRequired();
                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasColumnType("VARCHAR(255)")
                    .IsRequired();
                entity.Property(e => e.CustomerId)
                    .HasColumnName("CUSTOMER_ID")
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired();

                entity.HasIndex("OrderId", "ProductId", "CustomerId").IsUnique(); // Assumed to be a composite key
            });
        }
    }
}
