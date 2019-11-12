using System.Collections.Generic;
using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Log;
using Acme.SalesImporter.Models;
using Acme.SalesImporter.ServiceMappers;
using Acme.SalesImporter.Source.Interfaces;
using Acme.SalesImporter.Utils.Exceptions;

namespace Acme.SalesImporter
{
    public class Importer
    {
        private readonly IServiceMapper ServiceMapper;

        public Importer(IServiceMapper serviceMapper)
        {
            ServiceMapper = serviceMapper;
        }

        internal void Import(string source)
        {
            IStoreContext storeContext = ServiceMapper.StoreContext;
            storeContext.Connect();

            try
            {
                Store(Read(source));
                Logger.LogLine("Done.");
            }
            catch (SourceException srcEx)
            {
                Logger.LogLine(srcEx.Message);
                Logger.LogLine("Exiting.");
            }
            catch (DestinationException destEx)
            {
                Logger.LogLine(destEx.Message);
                Logger.LogLine("Exiting.");
            }
        }

        private void Store(IEnumerable<StoreOrder> storeOrders)
        {
            IStoreOrderRepository storeOrderRepository = ServiceMapper.StoreOrderRepository;
            storeOrderRepository.Add(storeOrders);
        }

        internal IEnumerable<StoreOrder> Read(string source)
        {
            IStoreOrderReader reader = ServiceMapper.StoreOrderReader;
            return reader.ReadSource(source);
        }
    }
}
