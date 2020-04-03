using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxServiceDemo.Models
{
    public class Order
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public IList<OrderItem> Items { get; set; }

        public double Total { get => Items?.Sum(i => i.TotalPrice) ?? 0; }

        public double ShippingTotal { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
