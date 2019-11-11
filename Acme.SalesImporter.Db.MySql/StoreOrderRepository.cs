using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Models;

namespace Acme.SalesImporter.Db.MySql
{
    public class StoreOrderRepository : IStoreOrderRepository
    {
        private StoreContext context;

        public async Task Add(IEnumerable<StoreOrder> storeOrders)
        {
            try
            {
                using (context ??= new StoreContext())
                {
                    foreach (var order in storeOrders)
                    {
                        await context.StoreOrders.AddAsync(order);
                    }

                    context.SaveChanges();
                }
            }
            catch (InvalidOperationException invalidOpEx)
            {
                Console.WriteLine(@"Some values are breaking the constrains. Failed.");
            }
        }

        public async Task Add(StoreOrder storeOrder)
        {
            try
            {
                using (context ??= new StoreContext())
                {
                    await context.StoreOrders.AddAsync(storeOrder);
                    context.SaveChanges();
                }
            }
            catch (InvalidOperationException invalidOpEx)
            {
                Console.WriteLine(@"Some values are breaking the constrains. Failed.");
            }
        }
    }
}
