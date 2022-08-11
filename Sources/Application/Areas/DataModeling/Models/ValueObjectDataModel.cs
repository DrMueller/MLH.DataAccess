using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    public abstract class ValueObjectDataModel<T> : IEquatable<T>
        where T : ValueObjectDataModel<T>
    {
        protected abstract IReadOnlyCollection<string> PropertyNamesToCompare { get; }

        public static bool operator ==(ValueObjectDataModel<T> x, ValueObjectDataModel<T> y)
        {
            return x != null && x.Equals(y);
        }

        public static bool operator !=(ValueObjectDataModel<T> x, ValueObjectDataModel<T> y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as T;
            return Equals(other);
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            var currentType = GetType();
            var otherType = other.GetType();

            if (currentType != otherType)
            {
                return false;
            }

            var fields = currentType
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(f => PropertyNamesToCompare.Contains(f.Name));

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var fields = GetFields();
            const int StartValue = 17;
            const int Multiplier = 59;
            var hashCode = StartValue;

            foreach (var field in fields)
            {
                var value = field.GetValue(this);
                if (value == null)
                {
                    continue;
                }

                var currentHash = hashCode * Multiplier;
                hashCode = currentHash + value.GetHashCode();
            }

            return hashCode;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var currentType = GetType();
            var fields = new List<FieldInfo>();

            while (currentType != typeof(object))
            {
                fields.AddRange(currentType!.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                currentType = currentType.GetTypeInfo().BaseType;
            }

            return fields;
        }
    }
}