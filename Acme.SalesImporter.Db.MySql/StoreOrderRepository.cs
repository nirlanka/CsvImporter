using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.SalesImporter.Db.MySql
{
    public class StoreOrderRepository : IStoreOrderRepository
    {
        private StoreContext context;

        public void Add(IEnumerable<StoreOrder> storeOrders)
        {
            try
            {
                using (context ??= new StoreContext())
                {
                    foreach (var order in storeOrders)
                    {
                        context.StoreOrders.AddAsync(order);
                    }

                    context.SaveChanges();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("ERROR: Some values are not compatible with the schema. Aborting.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERROR: Some required values are missing. Aborting.");
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("ERROR: Duplicate detected. Failed.");
                Console.WriteLine("  Order ID, Product ID and Customer ID should be unique.");
            }
        }
    }
}
