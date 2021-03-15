using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class ProductStoreViewModel
    {
        public List<Product> Products { get; set; }
        public List<Store> Stores { get; set; }
    }
}
