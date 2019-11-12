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
                entity.HasKey(e => e.Id);

                entity.Property(e => e.OrderId)
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired();
                entity.Property(e => e.OrderDate)
                    .HasColumnType("DATE")
                    .IsRequired();
                entity.Property(e => e.ShipDate)
                    .HasColumnType("DATE")
                    .IsRequired();
                entity.Property(e => e.ShipMode)
                    .HasColumnType("VARCHAR(20)");
                entity.Property(e => e.Quantity)
                    .HasColumnType("INT")
                    .IsRequired();
                entity.Property(e => e.Discount)
                    .HasColumnType("DECIMAL(3,2)");
                entity.Property(e => e.Profit)
                    .HasColumnType("DECIMAL(6,2)");
                entity.Property(e => e.ProductId)
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired();
                entity.Property(e => e.CustomerName)
                    .HasColumnType("VARCHAR(255)")
                    .IsRequired();
                entity.Property(e => e.Category)
                    .HasColumnType("VARCHAR(255)")
                    .IsRequired();
                entity.Property(e => e.CustomerId)
                    .HasColumnType("VARCHAR(20)")
                    .IsRequired();

                entity.HasIndex("OrderId", "ProductId", "CustomerId").IsUnique(); // Assumed to be a composite key
            });
        }
    }
}
