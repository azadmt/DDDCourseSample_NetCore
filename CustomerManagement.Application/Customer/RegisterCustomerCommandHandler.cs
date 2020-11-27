using CustomerManagement.ApplicationService.Contract.Customer;
using CustomerManagement.Domain.Customer;
using CustomerManagement.Domain.Customer.Service;
using Framework.Core;
using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.ApplicationService.Customer
{
    public class RegisterCustomerCommandHandler : CommandHandler, ICommandHandler<RegisterCustomerCommand>
    {
        ICustomerRepository _customerRepository;
        public RegisterCustomerCommandHandler(IUnitOfWork uow, ICustomerRepository customerRepository) : base(uow)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(RegisterCustomerCommand command)
        {
            var customer = new CustomerAggregate(command.FirstName, command.LastName, command.NationalCode);
            await _customerRepository.Save(customer);
        }
    }
}
