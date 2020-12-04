using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.QueryService.DataModel
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string NationalCode { get;  set; }
        public bool IsApprove { get;  set; }

        
    }
}
