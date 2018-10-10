namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    public abstract class DataModelBase<TId>
    {
        public string DataModelTypeName => GetType().FullName;
        public TId Id { get; set; }
    }
}