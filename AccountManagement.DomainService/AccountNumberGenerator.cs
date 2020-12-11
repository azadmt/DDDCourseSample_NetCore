using AccountManagement.Domain.Account;
using AccountManagement.Domain.AccountType;
using AccountManagement.Domain.Acl;
using System;

namespace AccountManagement.DomainService
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly IAccountOwnerService accountOwnerService;
        private readonly IAccountRepository accountRepository;
        private readonly IAccountTypeRepository accountTypeRepository;

        public AccountNumberGenerator(
            IAccountOwnerService accountOwnerService,
            IAccountRepository accountRepository,
            IAccountTypeRepository accountTypeRepository
            )
        {
            this.accountOwnerService = accountOwnerService;
            this.accountRepository = accountRepository;
            this.accountTypeRepository = accountTypeRepository;
        }
        public AccountNumber GenerateNumber(Guid accountOwnerId, Guid accountTypeId)
        {
            var accountOwner = accountOwnerService.GetAccountOwner(accountOwnerId);
            var accountType = accountTypeRepository.Get(accountTypeId);
            var ownerAccountTypeCount = accountRepository.GetOwnerAccountTypeCount(accountOwnerId, accountTypeId).Result;
            return new AccountNumber(accountOwner.NationalCode, accountType.Code,ownerAccountTypeCount);
        }
    }
}
