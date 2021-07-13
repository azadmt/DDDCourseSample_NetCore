using Autofac;
using Framework.Core.IOC;
using System;
using System.Collections.Generic;


namespace Framework.Configuration.Autofac
{
    public class AutofacContainer : Core.IOC.IContainer
    {
        public IComponentContext Container { get; }


        public AutofacContainer(IComponentContext container)
        {
            Container = container;
        }
        public IDisposable BeginScope()
        {
            return null;//return Container.sc.BeginLifetimeScope();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.Resolve<IEnumerable<T>>();
        }
    }
}
