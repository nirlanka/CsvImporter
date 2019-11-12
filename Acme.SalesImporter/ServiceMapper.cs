using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Db.MySql;
using Acme.SalesImporter.Source.Csv;
using Acme.SalesImporter.Source.Interfaces;

namespace Acme.SalesImporter
{
    public static class ServiceMapper
    {
        public static IStoreOrderReader StoreOrderReader
        {
            get
            {
                __storeOrderReader ??= new StoreOrderCsvReader();
                return __storeOrderReader;
            }
        }
        private static IStoreOrderReader __storeOrderReader;

        public static IStoreContext StoreContext
        {
            get
            {
                __storeContext ??= new StoreContext();
                return __storeContext;
            }
        }
        private static IStoreContext __storeContext;

        public static IStoreOrderRepository StoreOrderRepository
        {
            get
            {
                __storeOrderRepository ??= new StoreOrderRepository();
                return __storeOrderRepository;
            }
        }
        private static IStoreOrderRepository __storeOrderRepository;
    }
}
