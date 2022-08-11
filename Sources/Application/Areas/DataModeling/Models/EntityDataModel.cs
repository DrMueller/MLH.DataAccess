using JetBrains.Annotations;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    [PublicAPI]
    public abstract class EntityDataModel<TId>
    {
        public string DataModelTypeName => GetType().FullName;
        public TId Id { get; set; }

        public static bool operator ==(EntityDataModel<TId> a, EntityDataModel<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(EntityDataModel<TId> a, EntityDataModel<TId> b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityDataModel<TId>;

            if (ReferenceEquals(compareTo, null))
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return (GetType() + Id.ToString()).GetHashCode();
        }
    }
}