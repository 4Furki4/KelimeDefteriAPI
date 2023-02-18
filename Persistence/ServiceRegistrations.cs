using Application.Repositories.RecordRepository;
using Application.Repositories.WordRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.RecordRepository;
using Persistence.Repositories.WordRepository;
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
                opt.UseSqlServer(Configuration.GetConnectionString());
            });
            services.AddScoped<IRecordQueryRepository, RecordQueryRepository>();
            services.AddScoped<IRecordCommandRepository, RecordCommandRepository>();
            services.AddScoped<IWordQueryRepository, WordQueryRepository>();
            services.AddScoped<IWordCommandRepository, WordCommandRepository>();
            services.AddScoped<IRecordQueryRepository, RecordQueryRepository>();
            services.AddScoped<IRecordCommandRepository, RecordCommandRepository>();

        }
    }
}
