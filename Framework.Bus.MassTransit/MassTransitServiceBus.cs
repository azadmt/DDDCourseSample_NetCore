using Framework.Core;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Framework.Bus.MassTransit
{
    public class MassTransitServiceBus : IEnterpriseServiceBus
    {
        IBusControl massTransitBus;
        public MassTransitServiceBus(IBusControl busControl)
        {
            massTransitBus = busControl;
        }
        public async Task Publish<T>(T @event) where T : IIntegrationEvent
        {
            await massTransitBus.Publish(@event);
        }
    }
}
