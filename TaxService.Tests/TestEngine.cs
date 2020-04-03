using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxServiceDemo;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Tests
{
    public static class TestEngine
    {
        #region Addresses
        public static Address Address_US_FL_1 = new Address
        {
            Street = "224 Datura St",
            Street2 = "1300",
            City = "West Palm Beach",
            StateProvince = "FL",
            PostalCode = "33401",
            Country = "US"
        };

        public static Address Address_US_FL_2 = new Address
        {
            Street = "790 Juno Ocean Walk",
            Street2 = "402",
            City = "Juno Beach",
            StateProvince = "FL",
            PostalCode = "33408",
            Country = "US"
        };

        public static Address Address_CA_ON = new Address
        {
            Street = "874 Sinclair Rd",
            City = "Oakville",
            StateProvince = "ON",
            PostalCode = "L6K 2H3",
            Country = "CA"
        };
        
        public static Address Address_CA_QC = new Address
        {
            Street = "405 Chemin Vanier",
            City = "Gatineau",
            StateProvince = "QC",
            PostalCode = "J9J 3H9",
            Country = "CA"
        };
        #endregion

        #region Item Sets
        public static List<OrderItem> Items_Single_QTYMulti_Total70 = new List<OrderItem>
        {
            new OrderItem { SKU = "Prod1", Quantity = 7, PricePerUnit = 10.00 }
        };

        public static List<OrderItem> Items_Multi_QTYSingle_Total30 = new List<OrderItem>
        {
            new OrderItem { SKU = "Prod1", Quantity = 1, PricePerUnit = 10.00 },
            new OrderItem { SKU = "Prod2", Quantity = 1, PricePerUnit = 10.00 },
            new OrderItem { SKU = "Prod3", Quantity = 1, PricePerUnit = 10.00 },
        };

        public static List<OrderItem> Items_Multi_QTYMulti_Total30 = new List<OrderItem>
        {
            new OrderItem { SKU = "Prod1", Quantity = 2, PricePerUnit = 10.00 },
            new OrderItem { SKU = "Prod2", Quantity = 1, PricePerUnit = 10.00 }
        };

        public static List<OrderItem> Items_Empty = new List<OrderItem>
        {
        };

        #endregion

        #region Orders
        public static Order Order_FL_FL = new Order
        {
            BillingAddress = TestEngine.Address_US_FL_1,
            ShippingAddress = TestEngine.Address_US_FL_2,
            ShippingTotal = 0,
            Items = TestEngine.Items_Multi_QTYSingle_Total30
        };

        public static Order Order_FL_ON = new Order
        {
            BillingAddress = TestEngine.Address_US_FL_1,
            ShippingAddress = TestEngine.Address_CA_ON,
            ShippingTotal = 0,
            Items = TestEngine.Items_Multi_QTYMulti_Total30
        };

        public static Order Order_ON_QC_WithShipping = new Order
        {
            BillingAddress = TestEngine.Address_CA_ON,
            ShippingAddress = TestEngine.Address_CA_QC,
            ShippingTotal = 10.99,
            Items = TestEngine.Items_Single_QTYMulti_Total70
        };
        #endregion

        public static ApiProfiles GetProfiles()
        {
            ServiceProvider serviceProvider;
            var services = new ServiceCollection();
            services.AddOptions();

            var config = new ConfigurationBuilder()
                .AddJsonFile("test.settings.json")
                .Build();

            ApiProfiles profiles = new ApiProfiles();
            var profileConfigs = config.GetSection("ApiProfiles").GetChildren();

            profileConfigs.ToList().ForEach(p =>
            {
                profiles.Add(p.Key, p.Get<ApiProfile>());
            });

            config.GetSection("ApiProfiles").Bind(profiles);
            services.AddSingleton(profiles);

            serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetRequiredService<ApiProfiles>();
        }
    }
}
