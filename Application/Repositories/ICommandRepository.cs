using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entities);

        bool Remove(T entity);

        Task<bool> RemoveAsync(string id);

        bool Update(T entity);

        Task<int> SaveAsync();
    }
}
