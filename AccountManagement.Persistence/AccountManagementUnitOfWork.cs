using AccountManagement.Persistence.Mapping;
using CustomerManagement.Persistence;
using Framework.Core;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using System;

namespace AccountManagement.Persistence
{
    public class AccountManagementUnitOfWork:ApplicationDbContext
    {
        public AccountManagementUnitOfWork(DbContextOptions<CustomerManagementUnitOfWork> options, IBus bus)
            : base(options, bus)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AccountMapping().Map(modelBuilder);
        }
    }
}
