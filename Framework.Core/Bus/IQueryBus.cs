using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IQueryBus
    {
        Task<TQueryResult> Send<TQuery, TQueryResult>(TQuery query) where TQuery : ICommand;
    }
}
