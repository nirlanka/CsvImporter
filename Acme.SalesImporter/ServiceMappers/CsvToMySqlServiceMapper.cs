using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Db.MySql;
using Acme.SalesImporter.ServiceMappers;
using Acme.SalesImporter.Source.Csv;
using Acme.SalesImporter.Source.Interfaces;

namespace Acme.SalesImporter
{
    public class CsvToMySqlServiceMapper : IServiceMapper
    {
        public IStoreOrderReader StoreOrderReader
        {
            get
            {
                __storeOrderReader ??= new StoreOrderCsvReader();
                return __storeOrderReader;
            }
        }
        private IStoreOrderReader __storeOrderReader;

        public IStoreContext StoreContext
        {
            get
            {
                __storeContext ??= new StoreContext();
                return __storeContext;
            }
        }
        private IStoreContext __storeContext;

        public IStoreOrderRepository StoreOrderRepository
        {
            get
            {
                __storeOrderRepository ??= new StoreOrderRepository();
                return __storeOrderRepository;
            }
        }
        private IStoreOrderRepository __storeOrderRepository;
    }
}
