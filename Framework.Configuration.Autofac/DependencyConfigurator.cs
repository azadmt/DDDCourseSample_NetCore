using Autofac;
using Framework.Core;
using System.Threading.Tasks;

namespace Framework.Configuration.Autofac
{
    public class DependencyConfigurator
    {
        public static void Config(ContainerBuilder cb)
        {
            cb.RegisterType<BusControl>().As<IBus,IQueryBus>();
            cb.RegisterType<AutofacContainer>().As<Core.IOC.IContainer>();
           cb.RegisterType<MassTransitServiceBus>().As<IEnterpriseServiceBus>();

        }

    }

    public class MassTransitServiceBus : IEnterpriseServiceBus
    {
        public Task Publish<T>(T @event) where T : IIntegrationEvent
        {
            return Task.CompletedTask;
        }
    }
}
