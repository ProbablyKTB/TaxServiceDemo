using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxServiceDemo.Calculators;
using TaxServiceDemo.Models;

namespace TaxServiceDemo
{
    public class TaxService
    {
        private readonly ApiProfiles _profiles;
        private ICalculator _calculator;

        public TaxService(ApiProfiles profiles) 
        {
            _profiles = profiles;
        }
        public TaxService(ICalculator calc) 
        {
            SetCalculator(calc);
        }

        public void SetCalculator(ICalculator calc)
        {
            calc.ApiProfile ??= _profiles[calc.ProfileName];
            _calculator = calc;
        }

        public double GetTaxes(Order order)
        {
            return _calculator.GetTaxes(order);
        }
        public double GetTaxRate(Address location)
        {
            return _calculator.GetTaxRate(location);
        }
    }
}
