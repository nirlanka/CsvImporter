using Acme.SalesImporter.Db.Interfaces;
using Acme.SalesImporter.Source.Interfaces;

namespace Acme.SalesImporter.ServiceMappers
{
    public interface IServiceMapper
    {
        public IStoreOrderReader StoreOrderReader { get; }
        public IStoreContext StoreContext { get; }
        public IStoreOrderRepository StoreOrderRepository { get; }
    }
}
