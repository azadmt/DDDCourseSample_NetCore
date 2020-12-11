using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.Account
{
    public interface IAccountNumberGenerator
    {
        AccountNumber GenerateNumber(Guid accountOwnerId, Guid accountTypeId);
    }
}
