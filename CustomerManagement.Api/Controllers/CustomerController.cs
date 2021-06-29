using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.ApplicationService.Contract.Customer;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        IBus _bus;
        private readonly LinkGenerator linkGenerator;

        public CustomerController(IBus bus,LinkGenerator linkGenerator)
        {
            _bus = bus;
            this.linkGenerator = linkGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterCustomerCommand registerCustomerCommand)
        {
            await _bus.Send(registerCustomerCommand);
            return Ok();
        }
    }
}