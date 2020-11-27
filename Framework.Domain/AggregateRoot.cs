using Framework.Core;
using Framework.Core.Domain;
using System;
using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        protected AggregateRoot()
        {
        }

        protected AggregateRoot(Guid id) : base(id)
        {
        }


        public IList<IEvent> Changes { get; set; } = new List<IEvent>();


        public void AddEvent(IEvent @event)
        {
            Changes.Add(@event);
        }
    }
}
