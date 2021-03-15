using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "product_name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "product_url")]
        public string ProductUrl { get; set; }
        }
    }