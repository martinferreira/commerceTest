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
            ConfigureRepositories(services);
            ConfigureApis(services);
        }

        private static void ConfigureApis(IServiceCollection services)
        {
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
        }
    }
}
