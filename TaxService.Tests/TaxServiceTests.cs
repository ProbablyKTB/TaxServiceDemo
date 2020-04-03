using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaxServiceDemo;
using TaxServiceDemo.Calculators;

namespace TaxServiceDemo.Tests
{
    public class TaxServiceTests
    {
        public TaxService service;

        [SetUp]
        public void Setup() => service = new TaxService(TestEngine.GetProfiles());

        [Test]
        public void SetCalculator_ByOrder_SwitchingCalcsChangesResult()
        {
            service.SetCalculator(new Always999Calculator());
            Assert.AreEqual(service.GetTaxes(TestEngine.Order_FL_FL), 999, "This calc should always return 999.");
            service.SetCalculator(new Always10Calculator());
            Assert.AreEqual(service.GetTaxes(TestEngine.Order_FL_FL), 0, "This calc should always return 10.");
        }

        [Test]
        public void SetCalculator_ByAddress_SwitchingCalcsChangesResult()
        {
            service.SetCalculator(new Always999Calculator());
            Assert.AreEqual(service.GetTaxRate(TestEngine.Order_FL_FL.BillingAddress), 999, "This calc should always return 999.");
            service.SetCalculator(new Always10Calculator());
            Assert.AreEqual(service.GetTaxRate(TestEngine.Order_FL_FL.BillingAddress), 0, "This calc should always return 10.");
        }
    }
}
