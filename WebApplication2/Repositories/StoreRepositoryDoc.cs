using EFCore.BulkExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Repositories.Interfaces;

namespace WebApplication2.Repositories
{
    public class StoreRepositoryDoc : IRepositoryDoc<Store>
    {
        private readonly DataContext _context;
        private readonly ILogger<StoreRepositoryDoc> _logger;

        public StoreRepositoryDoc(DataContext context, ILogger<StoreRepositoryDoc> logger)
        {
            this._logger = logger;
            if (context == null) throw new ArgumentNullException("context");
            this._context = context;

        }

        public async Task BulkDeleteAsync(List<Store> entities)
        {
            await _context.BulkDeleteAsync<Store>(entities);
            await _context.SaveChangesAsync();
        }

        public void BulkInsert(List<Store> entities)
        {
            throw new NotImplementedException();
        }

        public async Task BulkUpsertAsync(List<Store> entities)
        {
            await _context.BulkInsertOrUpdateAsync<Store>(entities);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Store> GetAll()
        {
            return _context.Stores;
        }

        public Store GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Store entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Store entity)
        {
            throw new NotImplementedException();
        }
    }
}
