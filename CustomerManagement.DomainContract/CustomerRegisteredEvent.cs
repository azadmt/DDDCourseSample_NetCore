using Framework.Core;
using System;

namespace CustomerManagement.DomainContract
{
    public class CustomerRegisteredEvent:IEvent
    {
        public Guid CustomerId { get; }
        public CustomerRegisteredEvent(Guid customerId)
        {
            CustomerId = customerId;
        }       
    }
}
