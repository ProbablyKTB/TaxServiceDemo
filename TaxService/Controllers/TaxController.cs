using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaxServiceDemo.Calculators;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Controllers
{
    [ApiController]
    [Route("~/")]
    public class TaxController : ControllerBase
    {
        private readonly List<ICalculator> calculators;
        private readonly TaxService engine;
        public TaxController(ApiProfiles profiles)
        {
            calculators = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ICalculator).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (ICalculator)Activator.CreateInstance(x)).ToList();
            
            engine = new TaxService(profiles);
        }

        [Route("~/"), HttpGet]
        public string Default()
        {
            return "Tax Service Demo by Kendrick Barrett";
        }

        [Route("calcs"), HttpGet]
        public IEnumerable<string> GetCalculators()
        {
            return calculators.Select(c => c.Name);
        }

        [Route("taxes/{calc}"), HttpPost]
        public double GetTaxes(string calc, [FromBody] Order order)
        {
            engine.SetCalculator(calculators.FirstOrDefault(c => c.Name.Equals(calc, StringComparison.InvariantCultureIgnoreCase)));
            return engine.GetTaxes(order);
        }

        [Route("rate/{calc}"), HttpPost]
        public double GetTaxRate(string calc, [FromBody] Address address)
        {
            engine.SetCalculator(calculators.FirstOrDefault(c => c.Name.Equals(calc, StringComparison.InvariantCultureIgnoreCase)));
            return engine.GetTaxRate(address);
        }
    }
}
