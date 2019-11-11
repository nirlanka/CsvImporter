using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.SalesImporter.Models;
using Acme.SalesImporter.Source.Interfaces;
using Acme.SalesImporter.Utils;
using TinyCsvParser;

namespace Acme.SalesImporter.Source.Csv
{
    public class CsvReader : IReader
    {
        private readonly string[] EXPECTED_HEADERS = {
            "orderid",
            "orderdate",
            "shipdate",
            "shipmode",
            "quantity",
            "discount",
            "profit",
            "productid",
            "customername",
            "category",
            "customerid",
        };

        public async Task<IEnumerable<StoreOrder>> ReadSource(string source)
        {
            //TODO: Make reading each line async

            int[] columnIndexes;

            var fileStream = new FileStream(source, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                var _headersRow = reader.ReadLine();
                var headers = _headersRow.ToLower().Replace(" ", string.Empty).Split(",");

                columnIndexes = new int[EXPECTED_HEADERS.Length];

                foreach (var (expectedHeader, i) in EXPECTED_HEADERS.WithIndex())
                {
                    var idx = Array.FindIndex(headers, header => header == expectedHeader);
                    columnIndexes[i] = idx;
                }
            }

            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvMapper = new CsvToStoreOrderMapping(columnIndexes);
            var csvParser = new CsvParser<StoreOrder>(csvParserOptions, csvMapper);

            var storeOrders = csvParser
                .ReadFromFile(source, Encoding.ASCII).ToList()
                .Select(wrapper => wrapper.Result);

            return storeOrders;
        }
    }
}
