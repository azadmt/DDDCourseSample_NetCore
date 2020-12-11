using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.Account;
using Framework.Core;
using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Account
{
    public class AccountHandlers : CommandHandler, ICommandHandler<CreateAccountCommand>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountNumberGenerator accountNumberGenerator;

        public AccountHandlers(
            IUnitOfWork unitOfWork,
            IAccountRepository accountRepository,
            IAccountNumberGenerator accountNumberGenerator) : base(unitOfWork)
        {
            this.accountRepository = accountRepository;
            this.accountNumberGenerator = accountNumberGenerator;
        }


        public async Task Handle(CreateAccountCommand command)
        {
            var accountNumber = accountNumberGenerator.GenerateNumber(command.OwnerId, command.AccountType);
            var account = new AccountAggregate(command.OwnerId, command.AccountType, accountNumber);
            await accountRepository.Save(account);
        }
    }
}
