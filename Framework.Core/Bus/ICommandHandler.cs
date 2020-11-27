using Framework.Core.Persistence;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        IUnitOfWork Uow { get; }

        Task Handle(TCommand command);
    }
}
