using System;

namespace CustomerManagement.QueryService.Contract
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public bool IsApprove { get; set; }
    }
}
