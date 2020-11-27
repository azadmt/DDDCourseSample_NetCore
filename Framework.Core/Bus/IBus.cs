using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IBus
    {
        Task Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
