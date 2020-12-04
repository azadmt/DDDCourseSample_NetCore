using CustomerManagement.QueryService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagement.QueryService.Service
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private QueryDbContext _queryDbContext;
        public CustomerQueryService(QueryDbContext queryDbContext)
        {
            _queryDbContext = queryDbContext;
        }
        public IList<CustomerDto> SearchCustomer(CustomerQueryDto queryDto)
        {
            return (from c in _queryDbContext.Customers
                    where
                    c.FirstName.Equals(queryDto.FirstName) ||
                    c.LastName.Equals(queryDto.LastName) ||
                    c.NationalCode.Equals(queryDto.NationalCode)
                    select new CustomerDto {FirstName= c.FirstName,LastName=c.LastName,NationalCode=c.NationalCode })
                    .ToList();

        }
    }
}
