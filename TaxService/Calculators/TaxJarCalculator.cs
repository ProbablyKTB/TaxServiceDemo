using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaxServiceDemo.Models;
using TaxServiceDemo.Models.Apis.TaxJar.Sales;

namespace TaxServiceDemo.Calculators
{
    public class TaxJarCalculator : ICalculator
    {
        public bool IsSupported => true;

        public string DisplayName => "TaxJar";

        public string Name => "TaxJar";
        public string ProfileName => "TaxJar.Production";

        public ApiProfile ApiProfile { get; set; }

        public double GetTaxes(Order order)
        {
            var result = default(TaxesResult);
            try
            {
                var payload = new TaxesPayload(order);
                result = Post<TaxesResult>(ApiProfile.Endpoints["Taxes"], payload.ToString());
            }
            catch (Exception e)
            {
                //Log exception somewhere
            }

            return result?.Data?.AmountToCollect ?? 0;
        }

        public double GetTaxRate(Address location)
        {
            var result = default(RatesResult);
            try
            {
                var payload = new RatesPayload(location);
                result = Get<RatesResult>(string.Format("{0}/{1}", ApiProfile.Endpoints["Rates"], payload.ToString()));
            }
            catch (Exception e)
            {
                //Log exception somewhere
            }

            return result?.Data?.CombinedRate ?? 0;
        }

        private T Post<T>(string url, string dataJson)
        {
            using WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Headers[HttpRequestHeader.Authorization] = string.Format("Token token={0}", ApiProfile.ApiKey);

            return JObject.Parse(wc.UploadString(url, dataJson)).ToObject<T>(); 
        }

        private T Get<T>(string url)
        {
            using WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.Authorization] = string.Format("Token token={0}", ApiProfile.ApiKey);
            
            return JObject.Parse(wc.DownloadString(url)).ToObject<T>();           
        }
    }
}
