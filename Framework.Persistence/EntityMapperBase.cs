using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Framework.Persistence.Ef
{
    public abstract class EntityMapperBase<TEntity> where TEntity : Entity
    {
        public Type MapperType => typeof(TEntity);


        public virtual void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TEntity>().Ignore(nameof(AggregateRoot.Changes));
            modelBuilder.Entity<TEntity>()
                .Property(c => c.RowVersion)
                .IsRowVersion();
        }
    }    

}
