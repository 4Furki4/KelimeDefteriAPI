using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool isTracked = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracked = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracked = true);

        Task<T> GetByIdAsync(long id, bool isTracked = true);
    }
}
