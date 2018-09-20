using CommercePlacer.Api.OrderDetails;
using CommercePlacer.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Api.Injection
{
    public class Configuration
    {
        public static void ConfigureServices(IServiceCollection services, string environment)
        {
            ConfigureRepositories(services, environment);
            ConfigureApis(services);
        }

        private static void ConfigureApis(IServiceCollection services)
        {
            services.AddTransient<IOrderDetailsApi, OrderDetailsApi>();
        }

        private static void ConfigureRepositories(IServiceCollection services, string environment)
        {
            if (IsMockEnvironment(environment)) {
                services.AddScoped(typeof(IEntityRepository<>), typeof(MockRepository<>));
                
            }
            else
            {
                services.AddScoped(typeof(IEntityRepository<>), typeof(DatabaseRepository<>));
            }
        }

        private static bool IsMockEnvironment(string environment)
        {
            return true;
        }
    }
}
