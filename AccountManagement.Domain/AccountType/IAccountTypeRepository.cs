using System;

namespace AccountManagement.Domain.AccountType
{
    public interface IAccountTypeRepository
    {
        AccountTypeAggregate Get(Guid guid);
        void Save(AccountTypeAggregate accountTypeAggregate);
    }
}
