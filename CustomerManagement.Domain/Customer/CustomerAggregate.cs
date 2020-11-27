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

        public CustomerAggregate(string firstName, string lastName, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = new NationalCode(nationalCode);
        }
    }
}
