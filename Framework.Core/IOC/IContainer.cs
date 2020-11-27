using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.IOC
{
    public interface IContainer
    {
        T Resolve<T>();

        IEnumerable<T> ResolveAll<T>();

        IDisposable BeginScope();
    }
}
