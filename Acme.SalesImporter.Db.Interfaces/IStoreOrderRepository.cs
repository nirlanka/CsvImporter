using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.SalesImporter.Models;

namespace Acme.SalesImporter.Db.Interfaces
{
    public interface IStoreOrderRepository
    {
        public void Add(IEnumerable<StoreOrder> storeOrders);
    }
}
