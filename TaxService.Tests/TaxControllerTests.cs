using NUnit.Framework;
using System.Collections.Generic;
using TaxServiceDemo.Controllers;
using System.Linq;
using TaxServiceDemo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace TaxServiceDemo.Tests
{
    public class TaxControllerTests
    {
        private const string SERVICE_ENDPOINT = "http://localhost:44371";
        private TaxController controller;

        [SetUp]
        public void Setup()
        {
            controller = new TaxController(TestEngine.GetProfiles());
        }

        [Test]
        public void GetCalculators_CountShouldBe3()
        {
            var calcs = controller.GetCalculators();
            Assert.AreEqual(calcs.Count(), 3, "There should be 3 calculators in the service.");
        }

        [TestCase("Always999")]
        public void GetTaxRate_Always999Calc_ShouldReturn999(string calc)
        {
            Assert.AreEqual(controller.GetTaxes(calc, TestEngine.Order_FL_FL), 999, "This calc should always return 999.");
            Assert.AreEqual(controller.GetTaxes(calc, TestEngine.Order_FL_ON), 999, "This calc should always return 999.");
            Assert.AreEqual(controller.GetTaxes(calc, TestEngine.Order_ON_QC_WithShipping), 999, "This calc should always return 999.");
        }

        [TestCase("Always10")]
        public void GetTaxRate_Always10Calc_ShouldReturn0(string calc)
        {
            Assert.AreEqual(controller.GetTaxes(calc, TestEngine.Order_FL_FL), 0, "This calc should always return 0.");
            Assert.AreEqual(controller.GetTaxes(calc, TestEngine.Order_FL_ON), 0, "This calc should always return 0.");
            Assert.AreEqual(controller.GetTaxes(calc, TestEngine.Order_ON_QC_WithShipping), 0, "This calc should always return 0.");
        }
    }
}