using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxServiceDemo.Models.Apis.TaxJar.Sales
{
    public class TaxesResult
    {
        [JsonProperty("tax")]
        public Tax Data { get; set; }

        public class LineItem
        {
            [JsonProperty("city_amount")]
            public double CityAmount { get; set; }

            [JsonProperty("city_tax_rate")]
            public double CityTaxRate { get; set; }

            [JsonProperty("city_taxable_amount")]
            public double CityTaxableAmount { get; set; }

            [JsonProperty("combined_tax_rate")]
            public double CombinedTaxRate { get; set; }

            [JsonProperty("county_amount")]
            public double CountyAmount { get; set; }

            [JsonProperty("county_tax_rate")]
            public double CountyTaxRate { get; set; }

            [JsonProperty("county_taxable_amount")]
            public double CountyTaxableAmount { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("special_district_amount")]
            public double SpecialDistrictAmount { get; set; }

            [JsonProperty("special_district_taxable_amount")]
            public double SpecialDistrictTaxableAmount { get; set; }

            [JsonProperty("special_tax_rate")]
            public double SpecialTaxRate { get; set; }

            [JsonProperty("state_amount")]
            public double StateAmount { get; set; }

            [JsonProperty("state_sales_tax_rate")]
            public double StateSalesTaxRate { get; set; }

            [JsonProperty("state_taxable_amount")]
            public double StateTaxableAmount { get; set; }

            [JsonProperty("tax_collectable")]
            public double TaxCollectable { get; set; }

            [JsonProperty("taxable_amount")]
            public double TaxableAmount { get; set; }
        }

        public class Shipping
        {
            [JsonProperty("city_amount")]
            public double CityAmount { get; set; }

            [JsonProperty("city_tax_rate")]
            public double CityTaxRate { get; set; }

            [JsonProperty("city_taxable_amount")]
            public double CityTaxableAmount { get; set; }

            [JsonProperty("combined_tax_rate")]
            public double CombinedTaxRate { get; set; }

            [JsonProperty("county_amount")]
            public double CountyAmount { get; set; }

            [JsonProperty("county_tax_rate")]
            public double CountyTaxRate { get; set; }

            [JsonProperty("county_taxable_amount")]
            public double CountyTaxableAmount { get; set; }

            [JsonProperty("special_district_amount")]
            public double SpecialDistrictAmount { get; set; }

            [JsonProperty("special_tax_rate")]
            public double SpecialTaxRate { get; set; }

            [JsonProperty("special_taxable_amount")]
            public double SpecialTaxableAmount { get; set; }

            [JsonProperty("state_amount")]
            public double StateAmount { get; set; }

            [JsonProperty("state_sales_tax_rate")]
            public double StateSalesTaxRate { get; set; }

            [JsonProperty("state_taxable_amount")]
            public double StateTaxableAmount { get; set; }

            [JsonProperty("tax_collectable")]
            public double TaxCollectable { get; set; }

            [JsonProperty("taxable_amount")]
            public double TaxableAmount { get; set; }
        }

        public class Breakdown
        {
            [JsonProperty("city_tax_collectable")]
            public double CityTaxCollectable { get; set; }

            [JsonProperty("city_tax_rate")]
            public double CityTaxRate { get; set; }

            [JsonProperty("city_taxable_amount")]
            public double CityTaxableAmount { get; set; }

            [JsonProperty("combined_tax_rate")]
            public double CombinedTaxRate { get; set; }

            [JsonProperty("county_tax_collectable")]
            public double CountyTaxCollectable { get; set; }

            [JsonProperty("county_tax_rate")]
            public double CountyTaxRate { get; set; }

            [JsonProperty("county_taxable_amount")]
            public double CountyTaxableAmount { get; set; }

            [JsonProperty("line_items")]
            public IList<LineItem> LineItems { get; set; }

            [JsonProperty("shipping")]
            public Shipping Shipping { get; set; }

            [JsonProperty("special_district_tax_collectable")]
            public double SpecialDistrictTaxCollectable { get; set; }

            [JsonProperty("special_district_taxable_amount")]
            public double SpecialDistrictTaxableAmount { get; set; }

            [JsonProperty("special_tax_rate")]
            public double SpecialTaxRate { get; set; }

            [JsonProperty("state_tax_collectable")]
            public double StateTaxCollectable { get; set; }

            [JsonProperty("state_tax_rate")]
            public double StateTaxRate { get; set; }

            [JsonProperty("state_taxable_amount")]
            public double StateTaxableAmount { get; set; }

            [JsonProperty("tax_collectable")]
            public double TaxCollectable { get; set; }

            [JsonProperty("taxable_amount")]
            public double TaxableAmount { get; set; }
        }

        public class Jurisdictions
        {
            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("county")]
            public string County { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }
        }

        public class Tax
        {
            [JsonProperty("amount_to_collect")]
            public double AmountToCollect { get; set; }

            [JsonProperty("breakdown")]
            public Breakdown Breakdown { get; set; }

            [JsonProperty("freight_taxable")]
            public bool FreightTaxable { get; set; }

            [JsonProperty("has_nexus")]
            public bool HasNexus { get; set; }

            [JsonProperty("jurisdictions")]
            public Jurisdictions Jurisdictions { get; set; }

            [JsonProperty("order_total_amount")]
            public double OrderTotalAmount { get; set; }

            [JsonProperty("rate")]
            public double Rate { get; set; }

            [JsonProperty("shipping")]
            public double Shipping { get; set; }

            [JsonProperty("tax_source")]
            public string TaxSource { get; set; }

            [JsonProperty("taxable_amount")]
            public double TaxableAmount { get; set; }
        }
    }


}
