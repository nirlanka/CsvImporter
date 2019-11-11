using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.SalesImporter.Models;

namespace Acme.SalesImporter.Source.Interfaces
{
    public interface IStoreOrderReader
    {
        Task<IEnumerable<StoreOrder>> ReadSource(string source);
    }
}
