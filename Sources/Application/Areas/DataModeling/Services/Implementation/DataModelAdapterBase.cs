using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation
{
    public abstract class DataModelAdapterBase<TDataModel, TAggregateRoot, TId> : IDataModelAdapter<TDataModel, TAggregateRoot, TId>
        where TDataModel : DataModelBase<TId>
        where TAggregateRoot : AggregateRoot<TId>
    {
        private readonly IMapper _mapper;

        protected DataModelAdapterBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract TAggregateRoot Adapt(TDataModel dataModel);

        public virtual TDataModel Adapt(TAggregateRoot aggregateRoot)
        {
            return _mapper.Map<TDataModel>(aggregateRoot);
        }
    }
}