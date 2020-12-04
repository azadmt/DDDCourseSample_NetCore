using CustomerManagement.DomainContract;
using CustomerManagement.QueryService.DataModel;
using MassTransit;
using System.Threading.Tasks;

namespace CustomerManagement.QueryService.EventHandler
{
    public class CustomerRegisteredEventHandler : IConsumer<CustomerRegisteredEvent>
    {
        private readonly QueryDbContext _queryDbContext;
        public CustomerRegisteredEventHandler(QueryDbContext queryDbContext)
        {
            _queryDbContext = queryDbContext;
        }
        public async Task Consume(ConsumeContext<CustomerRegisteredEvent> context)
        {
                var customer = new Customer()
                {
                    Id = context.Message.Id,
                    FirstName = context.Message.FirstName,
                    LastName = context.Message.LastName,
                    NationalCode = context.Message.NationalCode,
                };
                _queryDbContext.Customers.Add(customer);
                await _queryDbContext.SaveChangesAsync();          
    
        }
    }
}
