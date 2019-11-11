using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Db.MySql;
using Acme.SalesImporter.Models;
using Acme.SalesImporter.Source.Csv;
using Acme.SalesImporter.Source.Interfaces;

namespace Acme.SalesImporter
{
    public static class Importer
    {
        internal static async Task Import(string source)
        {
            //TODO: Implement storing each read line async.

            await Store(await Read(source));
        }

        private static async Task Store(IEnumerable<StoreOrder> storeOrders)
        {
            IStoreOrderRepository storeOrderRepository = new StoreOrderRepository();
            await storeOrderRepository.Add(storeOrders);
        }

        internal static async Task<IEnumerable<StoreOrder>> Read(string source)
        {
            //TODO: Make these interfaces and classes injectable.

            IReader reader = new CsvReader();
            return await reader.ReadSource(source);
        }
    }
}
