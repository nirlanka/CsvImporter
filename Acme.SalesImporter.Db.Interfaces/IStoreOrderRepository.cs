using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.SalesImporter.Models;

namespace Acme.SalesImporter.Db.Interfaces
{
    public interface IStoreOrderRepository
    {
        public Task Add(IEnumerable<StoreOrder> storeOrders);
        public Task Add(StoreOrder storeOrder);
    }
}
