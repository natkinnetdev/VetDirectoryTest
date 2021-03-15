using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Repositories.Interfaces;
using EFCore.BulkExtensions;

namespace WebApplication2.Repositories
{
    public class ProductRepositoryDoc : IRepositoryDoc<Product>
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductRepositoryDoc> _logger;

        public ProductRepositoryDoc(DataContext context, ILogger<ProductRepositoryDoc> logger)
        {
            this._logger = logger;
            if (context == null) throw new ArgumentNullException("context");
            this._context = context;

        }

        public async Task  BulkDeleteAsync(List<Product> entities)
        {
            await _context.BulkDeleteAsync<Product>(entities);
            await _context.SaveChangesAsync();
        }

        public void BulkInsert(List<Product> entities)
        {
 
            throw new NotImplementedException();
        }

        public async Task BulkUpsertAsync(List<Product> entities)
        {
            await _context.BulkInsertOrUpdateAsync<Product>(entities);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
