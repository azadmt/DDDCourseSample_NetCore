using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Framework.Persistence.Ef
{
    public abstract class EntityMapperBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(nameof(AggregateRoot.Changes));
            builder
                  .Property(c => c.RowVersion)
                .IsRowVersion();
        }

    }
}
