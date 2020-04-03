using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Calculators
{
    public class Always10Calculator : ICalculator
    {
        public string DisplayName => "Definitely Always 10";
        public string Name => "Always10";
        public string ProfileName => null;

        public ApiProfile ApiProfile { get; set; }

        public double GetTaxes(Order order)
        {
            return 0;
        }

        public double GetTaxRate(Address location)
        {
            return 0;
        }
    }
}
