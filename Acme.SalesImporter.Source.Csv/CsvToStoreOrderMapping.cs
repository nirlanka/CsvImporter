using Acme.SalesImporter.Models;
using CsvHelper.Configuration;

namespace Acme.SalesImporter.Source.Csv
{
    public class CsvToStoreOrderMapping: ClassMap<StoreOrder>
    {
        public CsvToStoreOrderMapping()
        {
            Map(x => x.OrderId).Name("order id");
            Map(x => x.OrderDate).Name("order date").TypeConverterOption.Format("dd.MM.yy");
            Map(x => x.ShipDate).Name("ship date").TypeConverterOption.Format("dd.MM.yy"); ;
            Map(x => x.ShipMode).Name("ship mode");
            Map(x => x.Quantity).Name("quantity");
            Map(x => x.Discount).Name("discount");
            Map(x => x.Profit).Name("profit");
            Map(x => x.ProductId).Name("product id");
            Map(x => x.CustomerName).Name("customer name");
            Map(x => x.Category).Name("category");
            Map(x => x.CustomerId).Name("customer id");
        }
    }
}
