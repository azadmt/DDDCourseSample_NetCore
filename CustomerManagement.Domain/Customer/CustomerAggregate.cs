using CustomerManagement.DomainContract;
using Framework.Domain;
using System;
using System.Text;

namespace CustomerManagement.Domain.Customer
{
    public class CustomerAggregate : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public NationalCode NationalCode { get; private set; }
        public bool IsApprove { get; private set; }

        private CustomerAggregate()
        {
            //ORM 
        }
        public CustomerAggregate(string firstName, string lastName, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = new NationalCode(nationalCode);
            Changes.Add(new CustomerRegisteredEvent(Id, FirstName, LastName, NationalCode.Code));
        }

        public void Approve()
        {
            IsApprove = true;
        }
    }
}
