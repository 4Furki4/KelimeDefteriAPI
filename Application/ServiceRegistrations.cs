using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(med =>
            {
                med.RegisterServicesFromAssembly(typeof(ServiceRegistrations).Assembly);
            });
            services.AddAutoMapper(typeof(ServiceRegistrations).Assembly);
        }
    }
}
