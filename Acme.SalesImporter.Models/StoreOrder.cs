using System;

namespace Acme.SalesImporter.Models
{
    public class StoreOrder
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; } 
        public DateTime ShipDate { get; set; } 
        public string ShipMode { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float Profit { get; set; }
        public string ProductId { get; set; } 
        public string CustomerName { get; set; } 
        public string Category { get; set; } 
        public string CustomerId { get; set; } 
    }
}
