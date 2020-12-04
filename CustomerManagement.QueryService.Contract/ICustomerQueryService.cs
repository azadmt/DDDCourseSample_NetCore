using System.Collections;
using System.Collections.Generic;

namespace CustomerManagement.QueryService.Contract
{
    public interface ICustomerQueryService
    {
        IList<CustomerDto> SearchCustomer(CustomerQueryDto queryDto);
    }
}
