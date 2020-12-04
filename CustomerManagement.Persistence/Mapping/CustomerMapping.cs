using CustomerManagement.Domain.Customer;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Persistence.Mapping
{
    public class CustomerMapping: EntityMapperBase<CustomerAggregate>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            base.Map(modelBuilder);
            modelBuilder.Entity<CustomerAggregate>().Property(t => t.FirstName).IsRequired();
            modelBuilder.Entity<CustomerAggregate>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<CustomerAggregate>().OwnsOne(t => t.NationalCode);
        }
    }
}
