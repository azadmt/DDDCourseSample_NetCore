using Framework.Domain;
using System;

namespace LoanManagement.Domain.LoanAggregate
{
    public class LoanInstallment : Entity
    {
        public Money Amount { get; private set; }
        public Money Penalty { get; private set; }
        public DateTime PayDate { get; private set; }

    }
}
