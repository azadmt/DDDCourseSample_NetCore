using AccountManagement.Domain.Account;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Persistence.Mapping
{
    public class AccountMapping : EntityMapperBase<AccountAggregate>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            base.Map(modelBuilder);
            modelBuilder.Entity<AccountAggregate>().Property(t => t.OwnerId).IsRequired();
            modelBuilder.Entity<AccountAggregate>().OwnsOne(t => t.Number);
            modelBuilder.Entity<AccountAggregate>().Property(t => t.AccountType).IsRequired();
            modelBuilder.Entity<AccountAggregate>().OwnsOne(t => t.Balance);
        }
    }
}
