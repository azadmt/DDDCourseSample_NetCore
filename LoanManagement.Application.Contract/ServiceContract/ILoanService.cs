using LoanManagement.Application.Contract.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Application.Contract.ServiceContract
{
    public interface ILoanService
    {
         void CreateLoan(CreateLoan createLoan);
    }
}
