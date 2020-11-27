using Framework.Core.Persistence;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Customer.Service
{
    public interface ICustomerRepository: IRepository
    {
        Task<CustomerAggregate> Get(Guid id);
        Task Save(CustomerAggregate customerAggregate);
    }
}
