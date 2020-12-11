using Framework.Core;
using System;

namespace AccountManagement.Domain.Contract
{
    public class AccountCreatedEvent : IEvent
    {
        public  Guid OwnerId { get; private set; }
        public  Guid AccountType { get; private set; }
        public  string Number { get; private set; }
        public  decimal Balance { get; private set; }
        public AccountCreatedEvent(Guid ownerId, Guid accountType, string number, decimal balance)
        {
            Balance = balance;
            OwnerId = ownerId;
            AccountType = accountType;
            Number = number;
        }
    }
}
