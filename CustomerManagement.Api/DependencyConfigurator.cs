using CustomerManagement.ApplicationService.Customer;
using CustomerManagement.Persistence;
using CustomerManagement.Persistence.Repository;
using Framework.Core;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api
{
    public class DependencyConfigurator
    {
        public static void Config(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Framework.Config.DependencyConfigurator.Config(serviceCollection);

            serviceCollection.AddDbContext<CustomerManagementUnitOfWork>(options => options.UseSqlServer(configuration.GetConnectionString("WriteConnection")));
            serviceCollection.AddScoped<CustomerManagementUnitOfWork>();
            serviceCollection.AddScoped(typeof(IUnitOfWork), p => p.GetService<CustomerManagementUnitOfWork>());
            RegisterControllers(serviceCollection);
            RegisterCommandHandlers(serviceCollection);
            RegisterEventHandlers(serviceCollection);
            RegisterRepositories(serviceCollection);
        }

        private static void RegisterControllers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvc().AddControllersAsServices();
        }

        private static void RegisterCommandHandlers(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(scan =>
            {
                scan
                .FromAssemblyOf<RegisterCustomerCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                ;
            });
        }

        private static void RegisterEventHandlers(IServiceCollection serviceCollection)
        {

        }

        private static void RegisterRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(scan =>
            {
                scan
                .FromAssemblyOf<CustomerRepository>()
                .AddClasses(classes => classes.AssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                ;
            });
        }
    }
}
