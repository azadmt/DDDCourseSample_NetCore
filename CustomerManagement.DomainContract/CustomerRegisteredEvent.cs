using Framework.Core;
using System;

namespace CustomerManagement.DomainContract
{
    public class CustomerRegisteredEvent : IEvent, IIntegrationEvent
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public CustomerRegisteredEvent(Guid customerId, string firstName, string lastName, string nationalCode)
        {
            Id = customerId;
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
        }
    }
}
