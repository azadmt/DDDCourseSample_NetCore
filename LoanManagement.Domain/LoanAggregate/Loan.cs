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
        public LoanState State { get; private set; }
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
}
