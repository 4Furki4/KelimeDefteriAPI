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

        public DbSet<T> Table => context.Set<T>();

        public IQueryable<T> GetAll(bool isTracked = true)
        {
            var data = Table.AsQueryable();
            return isTracked ? data : data.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(long id, bool isTracked = true)
        {
            var table = Table.AsQueryable();
            table = isTracked ? table : table.AsNoTracking();
            //TODO: get the property using reflextion and check if it equals to id or not.
            //return await table.FirstOrDefaultAsync(b => long.Parse(b.GetType().GetProperty("Id").GetValue(b).ToString())  == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            var table = isTracked ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
            return await table.SingleOrDefaultAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            return isTracked ? Table.Where(expression) : Table.Where(expression).AsNoTracking();
        }
    }
}
