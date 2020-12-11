using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Account
{
    public interface IAccountRepository
    {
        Task<AccountAggregate> Get(Guid guid);
        Task<int> GetOwnerAccountTypeCount(Guid accountOwnerId, Guid accountTypeId);
        Task Save(AccountAggregate accountAggregate);
    }
}
