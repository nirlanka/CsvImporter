using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Acme.SalesImporter.Models;
using Acme.SalesImporter.Source.Interfaces;
using CsvHelper;

namespace Acme.SalesImporter.Source.Csv
{
    public class StoreOrderCsvReader : IStoreOrderReader
    {
        public async Task<IEnumerable<StoreOrder>> ReadSource(string source)
        {
            //TODO: Make reading each line async

            using (var reader = new StreamReader(source))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.PrepareHeaderForMatch =
                    (string header, int index) => header.ToLower().Replace(" ", string.Empty);
                csv.Configuration.RegisterClassMap<CsvToStoreOrderMapping>();

                return csv.GetRecords<StoreOrder>().ToList();
            }
        }
    }
}
