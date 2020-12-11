using AccountManagement.Domain.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Persistence.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository()
        {

        }
        public Task<AccountAggregate> Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetOwnerAccountTypeCount(Guid accountOwnerId, Guid accountTypeId)
        {
            throw new NotImplementedException();
        }

        public Task Save(AccountAggregate accountAggregate)
        {
            throw new NotImplementedException();
        }
    }
}
