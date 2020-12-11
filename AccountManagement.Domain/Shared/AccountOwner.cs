using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.Shared
{
    public class AccountOwner
    {
        public Guid Id { get; private set; }
        public string NationalCode { get; private set; }

        public AccountOwner(Guid id,string nationalCode)
        {
            Id = id;
            NationalCode = nationalCode;
        }
    }
}
