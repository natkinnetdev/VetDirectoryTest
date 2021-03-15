using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Services.Interfaces
{
    public interface IParsingService
    {
        Task<IEnumerable<Product>> GetAndTransformProducts();

        Task<IEnumerable<Store>> GetAndTransformStores();
    }
}
