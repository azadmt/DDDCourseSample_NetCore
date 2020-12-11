using Framework.Domain;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.AccountType
{
    public class AccountTypeAggregate : AggregateRoot
    {
        public string Code { get; private set; }
        public AccountTypeAggregate(string code)
        {
            Code = code;
        }
    }
}
