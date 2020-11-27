using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Domain.Customer.Exception
{
    public class CustomerNationalCodeIsNotValidException : DomainException
    {
        public CustomerNationalCodeIsNotValidException() : base("National Code is Invalid!!!")
        {

        }
    }
}
