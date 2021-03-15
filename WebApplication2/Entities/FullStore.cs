using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class FullStore
    {
        public string actionUrl { get; set; }
        public string googleMapsApi { get; set; }
        public string locale { get; set; }
        public dynamic locations { get; set; }
        public string queryString { get; set; }
        public int radius { get; set; }
        public List<int> radiusOptions { get; set; }
        public dynamic searchKey { get; set; }
        public List<Store> stores { get; set; }
        public string storesResultsHtml { get; set; }
    }
}
