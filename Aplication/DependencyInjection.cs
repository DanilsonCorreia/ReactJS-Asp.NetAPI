using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aplication.Mappings;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Aplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(cf =>
            {
                cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            MappingConfig.Configure();
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);

            return services;
        }
    }
}
