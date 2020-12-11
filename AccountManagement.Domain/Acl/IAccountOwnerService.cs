using AccountManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.Acl
{
  public  interface IAccountOwnerService
    {
        AccountOwner GetAccountOwner(Guid accountOwnerId);
    }
}
