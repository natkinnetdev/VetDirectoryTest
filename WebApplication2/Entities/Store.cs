using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class Store
    {
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "address1")]
        public string MainAddress { get; set; }
        [JsonProperty(PropertyName = "address2")]
        public string AdditionalAddress { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "stateCode")]
        public string StateCode { get; set; }
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "distance")]
        public double Distance { get; set; }
        [JsonProperty(PropertyName = "hideOnDirectory")]
        public bool HideOnDirectory { get; set; }
    }
}
