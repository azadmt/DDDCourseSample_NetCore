using Framework.Core;
using LoanManagement.Application.Contract.DataContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(INotificationService notificationService,IBus bus)
        {
           
            this.notificationService = notificationService;
            this.bus = bus;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly INotificationService notificationService;
        private readonly IBus bus;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            notificationService.Send("asdasd");
            bus.Send(new CreateLoan());
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
           
        }
    }


    public interface INotificationService
    {
        void Send(string msg);
    }

    public class NotificationService : INotificationService
    {
       public  void Send(string msg)
        {
            //
        }
    }
}
