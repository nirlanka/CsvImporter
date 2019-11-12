using System;
using System.Collections.Generic;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Models;
using Acme.SalesImporter.Utils.Exceptions;
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
                throw new DestinationException($"Some values are not compatible with the schema. Aborting.");
            }
            catch (ArgumentNullException)
            {
                throw new DestinationException($"Some required values are missing. Aborting.");
            }
            catch (DbUpdateException dbUpdateEx)
            {
                throw new DestinationException($"Database update failed.\n  --> {dbUpdateEx?.InnerException?.Message}");
            }
        }
    }
}
