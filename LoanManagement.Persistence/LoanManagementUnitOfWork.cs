using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace LoanManagement.Persistence
{
    public class LoanManagementUnitOfWork : ApplicationDbContext
    {
        public LoanManagementUnitOfWork(DbContextOptions<LoanManagementUnitOfWork> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoanManagementUnitOfWork).Assembly);
        }
    }
}
