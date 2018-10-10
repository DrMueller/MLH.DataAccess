namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    /// <summary>
    ///     This class represents the technical entity persisted into the data store
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class DataModelBase<TId>
    {
        public string DataModelTypeName => GetType().FullName;
        public TId Id { get; set; }
    }
}