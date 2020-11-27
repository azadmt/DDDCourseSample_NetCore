using Framework.Core.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Core
{
    public class BusControl : IBus, IQueryBus
    {
        private IList<object> _subscribers;
        private readonly Queue<IIntegrationEvent> _externalMessages;
        private readonly IEnterpriseServiceBus _enterpriseServiceBus;
        private readonly IContainer _container;
        public BusControl(/*IEnterpriseServiceBus enterpriseServiceBus,*/ IContainer container)
        {
            _subscribers = new List<object>();
            _externalMessages = new Queue<IIntegrationEvent>();
           // _enterpriseServiceBus = enterpriseServiceBus;
            _container = container;
        }

        public Task Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            var subscribers = GetEligibleSubscribers<TEvent>();
            foreach (var eventHandler in subscribers)
            {
                eventHandler.HandleAsync(eventToPublish);
            }

            if (eventToPublish is IIntegrationEvent)
            {
                //  _externalMessages.Enqueue((IIntegrationEvent)eventToPublish);
                _enterpriseServiceBus.Publish((IIntegrationEvent)eventToPublish);
            }
            return Task.CompletedTask;
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var handler = _container.Resolve<ICommandHandler<TCommand>>();

                await handler.Handle(command);
                await handler.Uow.Commit();
                //TODO : use Outbox Table
                //logger...
                PublishExternalMessages();
            }
            catch (Exception ex)
            {
              //  await handler.Uow.Rollback();
                throw ex;
            }
        }

        public Task Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            _subscribers.Add(eventHandler);
            return Task.CompletedTask;
        }

        private IEnumerable<IEventHandler<TEvent>> GetEligibleSubscribers<TEvent>() where TEvent : IEvent
        {
            var subscribers = _subscribers.Where(s => s is IEventHandler<TEvent>).OfType<IEventHandler<TEvent>>().ToList();

            var allResolvedHandlers = _container.ResolveAll<IEventHandler<TEvent>>();

            subscribers.AddRange(allResolvedHandlers);

            return subscribers;
        }

        private void PublishExternalMessages()
        {
            while (_externalMessages.Any())
            {
                //TODO : Handle Exception 
                var message = _externalMessages.Dequeue();
                _enterpriseServiceBus.Publish(message);
            }
        }

        public async Task<TQueryResult> Send<TQuery, TQueryResult>(TQuery query) where TQuery : ICommand
        {
            var handler = _container.Resolve<IQueryHandler<TQuery, TQueryResult>>();

            return await handler.Handle(query);
        }
    }
}
