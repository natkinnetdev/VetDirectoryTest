using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class FullProduct
    {
        public string displayMessage {get;set;}
        
        public List<Product> recs { get; set; }
        public string recoUUID { get; set; }
    }
}
