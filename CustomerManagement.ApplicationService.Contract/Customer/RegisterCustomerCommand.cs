using Framework.Core;
using System;

namespace CustomerManagement.ApplicationService.Contract.Customer
{
    public class RegisterCustomerCommand : ICommand
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}
