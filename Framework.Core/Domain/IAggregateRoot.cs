using Framework.Core;
using System.Collections.Generic;

namespace Framework.Core.Domain
{
    public interface IAggregateRoot
    {
        IList<IEvent> Changes { get; }
    }
}
