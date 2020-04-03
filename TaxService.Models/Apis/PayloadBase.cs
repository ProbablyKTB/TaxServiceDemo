using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxServiceDemo.Models.Apis
{
    public abstract class PayloadBase
    {
        [JsonIgnore]
        public JsonSerializerSettings SerializerSettings { get; set; }
        public PayloadBase()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, SerializerSettings);
        }
    }
}
