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
        public LoanState State{ get; private set; }
        public DateTime PayDate { get; private set; }
        public IReadOnlyCollection<LoanInstallment> LoanInstallments => _loanInstallments;

        public void Approve()
        {
            State = LoanState.Approved;
        }

        public void Reject()
        {
            State = LoanState.Rejected;
        }
        public void Pay()
        {
            State = LoanState.Paid;
        }

        public void PayInstallment(Money amount)
        {
           
        }
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
    public enum LoanState
    {
        Requested,
        Approved,
        Rejected,
        Paid,
        Settled

    }
}
