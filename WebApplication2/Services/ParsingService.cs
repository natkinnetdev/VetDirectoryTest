using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class ParsingService : IParsingService
    {
        static HttpClient client = new HttpClient();
        const string productUri = "https://e.cquotient.com/recs/bdkx-1800petmeds/Search-products-in-all-categories?callback=CQuotient._callback0&_=1615395153556&_device=windows&userId=&cookieId=abDkRzM1runZSVw8BGCdC86FQL&emailId=&anchors=id%3A%3A%7C%7Csku%3A%3A%7C%7Ctype%3A%3A%7C%7Calt_id%3A%3A&slotId=suggestion-products-m&slotConfigId=New%20Slot%20Configuration%20-%202021-02-23%2016%3A17%3A18&slotConfigTemplate=slots%2Fproduct%2FsuggestionProducts.isml&ccver=1.03&__cq_uuid=abDkRzM1runZSVw8BGCdC86FQL&v=v2.33.0&json=%7B%22userId%22%3A%22%22%2C%22cookieId%22%3A%22abDkRzM1runZSVw8BGCdC86FQL%22%2C%22emailId%22%3A%22%22%2C%22anchors%22%3A%5B%7B%22id%22%3A%22%22%2C%22sku%22%3A%22%22%2C%22type%22%3A%22%22%2C%22alt_id%22%3A%22%22%7D%5D%2C%22slotId%22%3A%22suggestion-products-m%22%2C%22slotConfigId%22%3A%22New%20Slot%20Configuration%20-%202021-02-23%2016%3A17%3A18%22%2C%22slotConfigTemplate%22%3A%22slots%2Fproduct%2FsuggestionProducts.isml%22%2C%22ccver%22%3A%221.03%22%2C%22__cq_uuid%22%3A%22abDkRzM1runZSVw8BGCdC86FQL%22%2C%22v%22%3A%22v2.33.0%22%7D";
        const string siteUri = "https://www.1800petmeds.com/on/demandware.store/Sites-1800petmeds-Site/default/Stores-FindStores?showMap=false";
        public async Task<IEnumerable<Product>> GetAndTransformProducts()
        {
            FullProduct products = null;
            string jsonResult = String.Empty;
            HttpResponseMessage response = await client.GetAsync(productUri);
            if (response.IsSuccessStatusCode)
            {

                jsonResult = await response.Content.ReadAsStringAsync();
                jsonResult = jsonResult.Replace("/**/ typeof CQuotient._callback0 === 'function' && CQuotient._callback0({\"Search-products-in-all-categories\":", "").Replace("});", "");
                var result = JsonConvert.DeserializeObject<FullProduct>(jsonResult);

            }
            products = JsonConvert.DeserializeObject<FullProduct>(jsonResult);
            return products.recs;
        }

        public async Task<IEnumerable<Store>> GetAndTransformStores()
        {
            FullStore rawResponse = null;
            dynamic json;
            HttpResponseMessage response = await client.GetAsync(siteUri);
            if (response.IsSuccessStatusCode)
            {
                rawResponse = await response.Content.ReadAsAsync<FullStore>();
                //json = await response.Content.ReadAsAsync<dynamic>();
            }
            return rawResponse.stores;
        }
    }
}
