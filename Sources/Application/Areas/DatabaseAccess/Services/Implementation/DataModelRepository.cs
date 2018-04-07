using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Implementation
{
    public class DataModelRepository<T> : IDataModelRepository<T>
        where T : DataModelBase
    {
        private readonly IMongoDbFilterDefinitionFactory<T> _filterDefinitionFactory;
        private readonly IMongoDbAccess _mongoDbAccess;

        public DataModelRepository(IMongoDbAccess mongoDbAccess, IMongoDbFilterDefinitionFactory<T> filterDefinitionFactory)
        {
            _mongoDbAccess = mongoDbAccess;
            _filterDefinitionFactory = filterDefinitionFactory;
        }

        public Task DeleteAsync(string id)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();
            return collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate) => await LoadByExpressionAsync(predicate);

        public async Task<T> LoadSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var allResults = await LoadAsync(predicate);
            var result = allResults.SingleOrDefault();
            return result;
        }

        public async Task<T> SaveAsync(T aggregateRoot)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();

            var filter = _filterDefinitionFactory.CreateFilterDefinition(x => x.Id == aggregateRoot.Id);
            var updateOptions = new FindOneAndReplaceOptions<T> { IsUpsert = true, ReturnDocument = ReturnDocument.After };
            var result = await collection.FindOneAndReplaceAsync(filter, aggregateRoot, updateOptions);
            return result;
        }

        private async Task<IReadOnlyCollection<T>> LoadByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();

            var filter = _filterDefinitionFactory.CreateFilterDefinition(predicate);
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }
    }
}