using AccountManagement.Domain.Contract;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.Account
{
    public class AccountAggregate : AggregateRoot
    {
        public Guid OwnerId { get; private set; }
        public Guid AccountType { get; private set; }
        public AccountNumber Number { get; private set; }
        public Money Balance { get; private set; }
        public AccountAggregate(Guid ownerId, Guid accountType, AccountNumber accountNumber)
        {
            OwnerId = ownerId;
            Number = accountNumber;
            AccountType = accountType;

            Changes.Add(new AccountCreatedEvent(OwnerId, AccountType, Number.Number, Balance.Amount));
        }
    }
}
