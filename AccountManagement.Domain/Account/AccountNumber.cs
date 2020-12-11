using Framework.Domain;
using System.Collections.Generic;

namespace AccountManagement.Domain.Account
{
    public class AccountNumber : ValueObject
    {
        public string Number { get; private set; }

        public AccountNumber(string ownerNationalCode, string accountTypeCode, int numberOfExistingThisAccountType)
        {
            Number = $"{ownerNationalCode}{accountTypeCode}{numberOfExistingThisAccountType.ToString().PadLeft(2, '0')}";
        }
        protected AccountNumber() { }

  
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { Number };
        }
    }
}