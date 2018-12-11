namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    public abstract class AggregateRootDataModel<TId> : EntityDataModel<TId>
    {
        public string DataModelTypeName => GetType().FullName;
    }
}