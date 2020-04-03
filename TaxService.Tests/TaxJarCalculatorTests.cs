using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaxServiceDemo.Calculators;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Tests
{
    public class TaxJarCalculatorTests
    {
        public TaxJarCalculator calc;
        public TaxJarCalculator calc_bad;

        [SetUp]
        public void Setup()
        {
            calc = new TaxJarCalculator();
            calc.ApiProfile = TestEngine.GetProfiles()[calc.ProfileName];

            calc_bad = new TaxJarCalculator();
            //Note that calc_bad does not have an ApiProfile set. This would occur if the ApiProfile configuration in the service was incorrect or missing
        }

        [Test]
        public void GetTaxes_ReturnsCorrectValue()
        {
            Assert.AreEqual(calc.GetTaxes(TestEngine.Order_FL_FL), 2.1, 0.000001);
            Assert.AreEqual(calc.GetTaxes(TestEngine.Order_ON_QC_WithShipping), 4.05, 0.000001);
        }

        [Test]
        public void GetRates_ReturnsCorrectValue()
        {
            Assert.AreEqual(calc.GetTaxRate(TestEngine.Address_US_FL_2), 0.07, 0.000001);
            Assert.AreEqual(calc.GetTaxRate(TestEngine.Address_CA_QC), 0.14975, 0.000001);
        }

        [Test]
        public void GetTaxes_IncorrectlyConfigured_ShouldReturn0()
        {
            Assert.AreEqual(calc_bad.GetTaxes(TestEngine.Order_FL_FL), 0, 0.000001);
            Assert.AreEqual(calc_bad.GetTaxes(TestEngine.Order_ON_QC_WithShipping), 0, 0.000001);
        }

        [Test]
        public void GetRates_IncorrectlyConfigured_ShouldReturn0()
        {
            Assert.AreEqual(calc_bad.GetTaxRate(TestEngine.Address_US_FL_2), 0, 0.000001);
            Assert.AreEqual(calc_bad.GetTaxRate(TestEngine.Address_CA_QC), 0, 0.000001);
        }
    }
}
