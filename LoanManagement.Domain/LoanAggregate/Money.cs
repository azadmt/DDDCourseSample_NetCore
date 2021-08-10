using Framework.Domain;
using System.Collections.Generic;

namespace LoanManagement.Domain.LoanAggregate
{
    public class Money : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
