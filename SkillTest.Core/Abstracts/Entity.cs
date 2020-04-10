using System;

namespace SkillTest.Core
{
    public abstract class Entity
    {
        public virtual long ID { get; protected set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (ID == 0 || other.ID == 0)
                return false;

            return Equals(ID,other.ID);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return Equals(a,b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (this.GetType().ToString() + ID).GetHashCode();
        }
    }
}