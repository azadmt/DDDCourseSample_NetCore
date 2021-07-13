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
        public WeatherForecastController(INotificationService notificationService)
        {
           
            this.notificationService = notificationService;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly INotificationService notificationService;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            notificationService.Send("asdasd");
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
