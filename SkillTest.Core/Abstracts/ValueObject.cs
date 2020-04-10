using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillTest.Core
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<string> AnemicValue();

        public override bool Equals(object obj)
        {
            if (!(obj is ValueObject other))
                return false;

            if (ReferenceEquals(other,this))
                return true;

            return AnemicValue().SequenceEqual(other.AnemicValue());
        }

        public override int GetHashCode()
        {
            return AnemicValue().Aggregate((x, y) => x + y).GetHashCode();
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return Equals(a,b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}