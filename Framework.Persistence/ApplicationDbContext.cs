using Framework.Core;
using Framework.Core.Domain;
using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Persistence.Ef
{
    public abstract class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private IBus _bus;

        protected ApplicationDbContext(DbContextOptions options, IBus bus)
            : base(options)
        {
            _bus = bus;
        }

        public async Task Commit()
        {
            var listOfChanges = ChangeTracker.Entries()
           .Where(x => x.State != EntityState.Unchanged && x.Entity is IAggregateRoot)
           .ToList()
           .SelectMany(p => (p.Entity as IAggregateRoot).Changes);

            await SaveChangesAsync();

            await PublishEvents(listOfChanges);

        }

        private Task PublishEvents(IEnumerable<IEvent> eventsToPublish)
        {
            foreach (var item in eventsToPublish)
            {
                _bus.Publish((dynamic)item);
            }
            return Task.CompletedTask;
        }

        public Task Rollback()
        {
            //https://stackoverflow.com/questions/5466677/undo-changes-in-entity-framework-entities
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }

            return Task.CompletedTask;
        }
    }

}
