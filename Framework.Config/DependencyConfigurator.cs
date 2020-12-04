using Framework.Bus.MassTransit;
using Framework.Core;
using Framework.Core.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Config
{
    public class DependencyConfigurator
    {        
        public static void Config(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBus, BusControl>();
            serviceCollection.AddScoped<IQueryBus, BusControl>();
            serviceCollection.AddScoped<IContainer, Container>();
            serviceCollection.AddScoped<IEnterpriseServiceBus, MassTransitServiceBus>();
        }

    }
}
