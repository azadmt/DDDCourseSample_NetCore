using AccountManagement.Domain.Acl;
using AccountManagement.Domain.Shared;
using System;

namespace AccountManagement.CustomerManagement.Acl
{
    public class AccountOwnerService : IAccountOwnerService
    {
        public AccountOwner GetAccountOwner(Guid accountOwnerId)
        {
            //Get Data Fom Api 
            return new AccountOwner(Guid.NewGuid(),"CustomerNationalCode");
        }
    }
}
