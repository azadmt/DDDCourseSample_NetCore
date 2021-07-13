
using Autofac;
using Castle.DynamicProxy;
using Framework.Core;
using LoanManagement.Api.Controllers;
using LoanManagement.Application;
using LoanManagement.Application.Contract.DataContract;
using LoanManagement.Application.Contract.ServiceContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoanManagement.Api", Version = "v1" });
            });

            //https://blog.zhaytam.com/2020/08/18/aspnetcore-dynamic-proxies-for-aop/
            var proxyGenerator = new ProxyGenerator();
            var actual = new LoanManagement.Application.LoanService();
          //var proxiedService = (ILoanService)proxyGenerator.CreateInterfaceProxyWithTarget(typeof(ILoanService), actual, new LoggingInterceptor());

            //services.AddSingleton(new ProxyGenerator());
            //services.AddScoped<IInterceptor, LoggingInterceptor>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Framework.Configuration.Autofac.DependencyConfigurator.Config(builder);
            // If you want to set up a controller for, say, property injection
            // you can override the controller registration after populating services.
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<LoanCommandHandler>().As<ICommandHandler<CreateLoan>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoanManagement.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.LogDebug($"Calling method {invocation.TargetType}.{invocation.Method.Name}.");
            invocation.Proceed();
        }
    }
}
