using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Repositories.Interfaces
{
    public interface IRepositoryDoc<T>
    {
        T GetItem(int id);

        void Insert(T entity);

        void Remove(T entity);

        IEnumerable<T> GetAll();

        Task BulkUpsertAsync(List<T> entities);

        void BulkInsert(List<T> entities);

        Task BulkDeleteAsync(List<T> entities);
    }
}
