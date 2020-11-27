using Framework.Core.Persistence;

namespace Framework.Core
{
    public abstract class CommandHandler
    {
        public IUnitOfWork Uow { get; private set; }
        public CommandHandler(IUnitOfWork uow)
        {
            Uow = uow;
        }
    }
}
