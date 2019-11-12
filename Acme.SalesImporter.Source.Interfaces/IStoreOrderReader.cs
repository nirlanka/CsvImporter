using System.Collections.Generic;
using Acme.SalesImporter.Models;

namespace Acme.SalesImporter.Source.Interfaces
{
    public interface IStoreOrderReader
    {
        IEnumerable<StoreOrder> ReadSource(string source);
    }
}
