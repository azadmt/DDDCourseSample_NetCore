using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T eventToHandle);
    }
}
