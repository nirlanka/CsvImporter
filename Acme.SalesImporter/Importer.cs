using System;
using System.Collections.Generic;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Models;
using Acme.SalesImporter.Source.Interfaces;

namespace Acme.SalesImporter
{
    public static class Importer
    {
        internal static void Import(string source)
        {
            IStoreContext storeContext = ServiceMapper.StoreContext;
            storeContext.Connect();

            Store(Read(source));
            Console.WriteLine("Done.");
        }

        private static void Store(IEnumerable<StoreOrder> storeOrders)
        {
            IStoreOrderRepository storeOrderRepository = ServiceMapper.StoreOrderRepository;
            storeOrderRepository.Add(storeOrders);
        }

        internal static IEnumerable<StoreOrder> Read(string source)
        {
            IStoreOrderReader reader = ServiceMapper.StoreOrderReader;
            return reader.ReadSource(source);
        }
    }
}
