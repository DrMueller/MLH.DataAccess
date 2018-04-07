using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Services
{
    public interface IDataModelAdapter<TDataModel, TAggregateRoot>
        where TDataModel : DataModelBase
        where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot Adapt(TDataModel dataModel);

        TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}