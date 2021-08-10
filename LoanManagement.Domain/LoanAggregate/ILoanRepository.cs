using System;

namespace LoanManagement.Domain.LoanAggregate
{
    public interface ILoanRepository
    {
        void Save(Loan loan);
        void Update(Loan loan);
        Loan Get(Guid id);
    }
}
