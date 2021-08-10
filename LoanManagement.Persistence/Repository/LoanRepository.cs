using LoanManagement.Domain.LoanAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Persistence.Repository
{
    public class LoanRepository : ILoanRepository
    {
        LoanManagementUnitOfWork _uow;
        public LoanRepository(LoanManagementUnitOfWork uow)
        {
            _uow = uow;

        }
        public Loan Get(Guid id)
        {
            return _uow.Set<Loan>().Single(p => p.Id == id);
        }

        public void Save(Loan loan)
        {
             _uow.Set<Loan>().Add(loan);
        }

        public void Update(Loan loan)
        {
            _uow.Set<Loan>().Update(loan);
        }
    }
}
