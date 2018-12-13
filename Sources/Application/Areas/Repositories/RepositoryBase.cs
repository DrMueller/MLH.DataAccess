using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;

namespace Mmu.Mlh.DataAccess.Areas.Repositories
{
    public abstract class RepositoryBase<TAggregateRoot, TDataModel, TId> : IRepository<TAggregateRoot, TId>
        where TAggregateRoot : AggregateRoot<TId>
        where TDataModel : AggregateRootDataModel<TId>
    {
        private readonly IDataModelAdapter<TDataModel, TAggregateRoot, TId> _dataModelAdapter;
        private readonly IDataModelRepository<TDataModel, TId> _dataModelRepository;

        protected RepositoryBase(IDataModelRepository<TDataModel, TId> dataModelRepository, IDataModelAdapter<TDataModel, TAggregateRoot, TId> dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task DeleteAsync(TId id)
        {
            await _dataModelRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<TAggregateRoot>> LoadAllAsync()
        {
            var allDataModels = await _dataModelRepository.LoadAsync(f => true);
            var result = allDataModels.Select(_dataModelAdapter.Adapt).ToList();
            return result;
        }

        public async Task<TAggregateRoot> LoadByIdAsync(TId id)
        {
            var dataModel = await _dataModelRepository.LoadSingleAsync(f => f.Id.Equals(id));
            if (dataModel == null)
            {
                return null;
            }

            var aggregateRoot = _dataModelAdapter.Adapt(dataModel);
            return aggregateRoot;
        }

        public async Task<TAggregateRoot> SaveAsync(TAggregateRoot aggregateRoot)
        {
            var dataModel = _dataModelAdapter.Adapt(aggregateRoot);
            var returnedDataModel = await _dataModelRepository.SaveAsync(dataModel);

            var result = _dataModelAdapter.Adapt(returnedDataModel);
            return result;
        }
    }
}