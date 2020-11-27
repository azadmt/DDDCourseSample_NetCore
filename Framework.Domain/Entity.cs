using System;

namespace Framework.Domain
{
    public class Entity : IEquatable<Entity>
    {

        public Entity() : this(Guid.NewGuid())
        {
        }

        public Entity(Guid id)
        {
            this.id = id;
        }

        private Guid id;
        public virtual Guid Id { get => id; }

        public virtual byte[] RowVersion { get; protected set; }

        public virtual bool Equals(Entity other)
        {
            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return base.Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
