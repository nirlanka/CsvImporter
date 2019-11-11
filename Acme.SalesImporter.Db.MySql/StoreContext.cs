using System;
using System.IO;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Acme.SalesImporter.Db.MySql
{
    public class StoreContext: DbContext, IStoreContext
    {
        public DbSet<StoreOrder> StoreOrders { get; set; }

        public void Connect()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("MySqlDb");

            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityMapper.Map(modelBuilder);
        }
    }
}
