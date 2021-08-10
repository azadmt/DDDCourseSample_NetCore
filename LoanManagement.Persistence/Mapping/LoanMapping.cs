using Framework.Persistence.Ef;
using LoanManagement.Domain.LoanAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Persistence.Mapping
{
    public class LoanMapping : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OwnerId);
            builder.Property(x => x.PayDate);
            builder.Property(x => x.State);


            builder.OwnsOne(x => x.Amount);
            builder.HasMany(e => e.LoanInstallments)
              .WithOne() // or `WithOne() in case there is no inverse navigation property
               .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
       // https://stackoverflow.com/questions/60617430/ef-core-3-configure-backing-field-of-navigation-property
           // builder.Metadata.FindNavigation(nameof(Loan.LoanInstallments)).SetField("_loanInstallments");
        }

        public virtual void Map(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Loan>()
        }
    }
}
