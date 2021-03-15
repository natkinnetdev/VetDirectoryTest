using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Services.Interfaces
{
    public interface IVetDirectoryService
    {
        Product GetProductById(int id);
        void InsertProduct(Product product);
        Task InsertProductsAsync(List<Product> product);
        Task InsertStoresAsync(List<Store> store);

        Task RemoveProductsAsync(List<Product> product);
        Task RemoveStoresAsync(List<Store> store);
        void RemoveProduct(Product product);
        IEnumerable<Product> GetAllProducts();

        Store GetStoreById(int id);
        void InsertStore(Store store);
        void RemovStore(Store store);
        IEnumerable<Store> GetAllStores();
    }
}
