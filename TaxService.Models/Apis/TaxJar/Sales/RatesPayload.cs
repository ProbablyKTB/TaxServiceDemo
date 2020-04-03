using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TaxServiceDemo.Models;

namespace TaxServiceDemo.Models.Apis.TaxJar.Sales
{
    public class RatesPayload : PayloadBase
    {
        public RatesPayload() { }

        public RatesPayload(Address address)
        {
            Country = address.Country;
            Zip = address.PostalCode;
            State = address.StateProvince;
            City = address.City;
            Street = address.Street;
        }

        public override string ToString()
        {
            var objDict = JsonConvert.DeserializeObject<IDictionary<string, string>>(base.ToString());

            return string.Format("{0}?{1}",
                Zip,
                string.Join("&", objDict.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value))));
        }

        [JsonProperty("country")]
        public string Country { get; set; }

        private string _zip; 
        [JsonIgnore]
        public string Zip { get => _zip; set => _zip = value?.Replace(" ", ""); }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }
    }
}
