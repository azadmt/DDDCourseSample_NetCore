using Framework.Domain;
using System;
using System.Collections.Generic;

namespace LoanManagement.Domain.LoanAggregate
{
    public class Loan : Entity
    {
        private List<LoanInstallment> _loanInstallments;
        public Loan()
        {

        }
        public Guid OwnerId { get; private set; }
        public Money Amount { get; private set; }
        public DateTime PayDate { get; private set; }
        public IReadOnlyCollection<LoanInstallment> LoanInstallments => _loanInstallments;

    }

    public class LoanInstallment : Entity
    {
        public Money Amount { get; private set; }
        public Money Penalty { get; private set; }
        public DateTime PayDate { get; private set; }

    }

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
