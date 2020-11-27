using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IEnterpriseServiceBus
    {
        Task Publish<T>(T @event) where T : IIntegrationEvent;
    }
}
