using CustomerManagement.Persistence.Mapping;
using Framework.Core;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerManagement.Persistence
{
    public class CustomerManagementUnitOfWork : ApplicationDbContext
    {
        public CustomerManagementUnitOfWork(DbContextOptions<CustomerManagementUnitOfWork> options, IBus bus) : base(options, bus)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerMapping().Map(modelBuilder);
        }
    }
}
