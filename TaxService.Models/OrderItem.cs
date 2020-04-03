using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxServiceDemo.Models
{
    public class OrderItem
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }

        public double TotalPrice { get => Quantity * PricePerUnit; }
    }
}
