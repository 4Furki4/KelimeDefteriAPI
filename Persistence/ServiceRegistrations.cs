using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistrations
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<KelimeDefteriAPIContext>(opt =>
            {
                opt.UseSqlServer(IConfiguration["ConnectionStrings:KelimeDefteriAPIDB"]);
            });
        }
    }
}
