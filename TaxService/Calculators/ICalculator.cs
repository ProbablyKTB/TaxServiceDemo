using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Calculators
{
    public interface ICalculator
    {
        public string DisplayName { get;  }
        public string Name { get; }

        public string ProfileName { get; }

        public double GetTaxes(Order order);
        public double GetTaxRate(Address location);
        public ApiProfile ApiProfile { get; set; }
    }
}
