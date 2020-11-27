using CustomerManagement.Domain.Customer;
using CustomerManagement.Domain.Customer.Service;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerManagementUnitOfWork _unitOfWork;
        public CustomerRepository(CustomerManagementUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<CustomerAggregate> Get(Guid id)
        {
            return _unitOfWork.Set<CustomerAggregate>().SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Save(CustomerAggregate customerAggregate)
        {
            await _unitOfWork.Set<CustomerAggregate>().AddAsync(customerAggregate);

        }
    }
}
