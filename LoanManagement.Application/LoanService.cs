using Framework.Core;
using Framework.Core.Persistence;
using LoanManagement.Application.Contract.DataContract;
using LoanManagement.Application.Contract.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Application
{
    public class LoanService : ILoanService
    {
        public void CreateLoan(CreateLoan createLoan)
        {
            throw new NotImplementedException();
        }
    }


    public class LoanCommandHandler: ICommandHandler<CreateLoan>
    {
        public IUnitOfWork Uow => default(IUnitOfWork);


        public Task Handle(CreateLoan command)
        {
          return  Task.CompletedTask;
        }
    }
}
