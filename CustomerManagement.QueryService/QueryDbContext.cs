using CustomerManagement.QueryService.DataModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerManagement.QueryService
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
