using Framework.Core.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Framework.Config
{
    public class Container : IContainer
    {
        private readonly IServiceProvider serviceProvider;
        public Container(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IDisposable BeginScope()
        {
            return serviceProvider.CreateScope();
        }

        public T Resolve<T>()
        {
           return serviceProvider.GetService<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return serviceProvider.GetServices<T>();
        }
    }
}
