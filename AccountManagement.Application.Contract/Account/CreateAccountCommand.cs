using Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccountCommand : ICommand
    {
        public Guid OwnerId { get; set; }
        public Guid AccountType { get; set; }
    }
}
