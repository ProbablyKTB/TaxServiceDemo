using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxServiceDemo.Models.Apis.TaxJar.Sales
{
    public class RatesResult
    {
        [JsonProperty("rate")]
        public Rate Data { get; set; }

        public class Rate
        {
            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("city_rate")]
            public double CityRate { get; set; }

            [JsonProperty("combined_district_rate")]
            public string CombinedDistrictRate { get; set; }

            [JsonProperty("combined_rate")]
            public double CombinedRate { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("country_rate")]
            public double CountryRate { get; set; }

            [JsonProperty("county")]
            public string County { get; set; }

            [JsonProperty("county_rate")]
            public double CountyRate { get; set; }

            [JsonProperty("freight_taxable")]
            public bool FreightTaxable { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("state_rate")]
            public double StateRate { get; set; }

            [JsonProperty("zip")]
            public string Zip { get; set; }
        }
    }
}
