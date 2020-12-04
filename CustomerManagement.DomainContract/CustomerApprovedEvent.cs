using Framework.Core;
using System;

namespace CustomerManagement.DomainContract
{
    public class CustomerApprovedEvent : IEvent, IIntegrationEvent
    {
        public Guid Id { get; private set; }

        public CustomerApprovedEvent(Guid id)
        {
            Id = id;
        }
    }
}
