using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Repositories.Interfaces;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class VetDirectoryService : IVetDirectoryService
    {
        private readonly IRepositoryDoc<Product> _productRepository;
        private readonly IRepositoryDoc<Store> _storeRepository;
        private readonly ILogger<VetDirectoryService> _logger;

        public VetDirectoryService(IRepositoryDoc<Product> productRepository, IRepositoryDoc<Store> storeRepository, ILogger<VetDirectoryService> logger)
        {
            this._logger = logger;
            this._productRepository = productRepository;
            this._storeRepository = storeRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this._productRepository.GetAll();
        }

        public IEnumerable<Store> GetAllStores()
        {
           return this._storeRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Store GetStoreById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task InsertProductsAsync(List<Product> product)
        {
           await _productRepository.BulkUpsertAsync(product);
        }

        public void InsertStore(Store store)
        {
            throw new NotImplementedException();
        }

        public async Task InsertStoresAsync(List<Store> store)
        {
            await _storeRepository.BulkUpsertAsync(store);
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveProductsAsync(List<Product> product)
        {
            await _productRepository.BulkDeleteAsync(product);
        }

        public async Task RemoveStoresAsync(List<Store> store)
        {
            await _storeRepository.BulkDeleteAsync(store);
        }

        public void RemovStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
