using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Calculators
{
    public class Always999Calculator : ICalculator
    {
        public string DisplayName => "Literally Always 999";

        public string Name => "Always999";
        public string ProfileName => null;

        public ApiProfile ApiProfile { get; set; }

        public double GetTaxes(Order order)
        {
            return 999;
        }

        public double GetTaxRate(Address location)
        {
            return 999;
        }
    }
}
