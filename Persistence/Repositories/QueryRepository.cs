using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        readonly KelimeDefteriAPIContext context;

        public QueryRepository(KelimeDefteriAPIContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => throw new NotImplementedException();

        public IQueryable<T> GetAll(bool isTracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id, bool isTracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            throw new NotImplementedException();
        }
    }
}
