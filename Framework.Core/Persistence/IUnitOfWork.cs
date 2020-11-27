using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
