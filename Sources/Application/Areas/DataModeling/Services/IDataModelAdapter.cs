using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Services
{
    public interface IDataModelAdapter<TDataModel, TAggregateRoot, TId>
        where TDataModel : DataModelBase<TId>
        where TAggregateRoot : AggregateRoot<TId>
    {
        TAggregateRoot Adapt(TDataModel dataModel);

        TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}