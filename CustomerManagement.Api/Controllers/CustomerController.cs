using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.ApplicationService.Contract.Customer;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        IBus _bus;
        public CustomerController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterCustomerCommand registerCustomerCommand)
        {
            await _bus.Send(registerCustomerCommand);
            return Ok();
        }
    }
}