using Acme.SalesImporter.Models;
using TinyCsvParser.Mapping;

namespace Acme.SalesImporter.Source.Csv
{
    public class CsvToStoreOrderMapping: CsvMapping<StoreOrder>
    {
        public CsvToStoreOrderMapping(int[] columnIndexes) : base()
        {
            var i = 0;

            MapProperty(columnIndexes[i++], x => x.OrderId);
            MapProperty(columnIndexes[i++], x => x.OrderDate);
            MapProperty(columnIndexes[i++], x => x.ShipDate);
            MapProperty(columnIndexes[i++], x => x.ShipMode);
            MapProperty(columnIndexes[i++], x => x.Quantity);
            MapProperty(columnIndexes[i++], x => x.Discount);
            MapProperty(columnIndexes[i++], x => x.Profit);
            MapProperty(columnIndexes[i++], x => x.ProductId);
            MapProperty(columnIndexes[i++], x => x.CustomerName);
            MapProperty(columnIndexes[i++], x => x.Category);
            MapProperty(columnIndexes[i++], x => x.CustomerId);
        }
    }
}
