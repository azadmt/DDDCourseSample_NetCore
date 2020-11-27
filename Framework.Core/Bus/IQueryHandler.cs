using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IQueryHandler<TQuery, TQueryResult> where TQuery : ICommand
    {
        Task<TQueryResult> Handle(TQuery query);
    }
}
