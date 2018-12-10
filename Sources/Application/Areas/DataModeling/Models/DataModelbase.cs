﻿namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    /// <summary>
    ///     This class represents the technical entity persisted into the data store
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class DataModelBase<TId>
    {
        public string DataModelTypeName => GetType().FullName;
        public virtual TId Id { get; set; }

        public static bool operator ==(DataModelBase<TId> a, DataModelBase<TId> b)
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

        public static bool operator !=(DataModelBase<TId> a, DataModelBase<TId> b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DataModelBase<TId>;

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
            return (GetType() + Id.ToString()).GetHashCode();
        }
    }
}