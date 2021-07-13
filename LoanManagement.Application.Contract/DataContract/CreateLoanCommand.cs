using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Application.Contract.DataContract
{
    public class CreateLoan : ICommand
    {
        public Decimal Amount { get; set; }
    }
}
