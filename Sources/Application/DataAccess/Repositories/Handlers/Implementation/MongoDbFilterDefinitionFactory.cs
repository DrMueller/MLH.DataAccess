using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories.Handlers.Implementation
{
    public class MongoDbFilterDefinitionFactory<T> : IMongoDbFilterDefinitionFactory<T>
        where T : AggregateRoot
    {
        public FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate)
        {
            var entityTypeFilter = CreateEntityTypeFilterDefinition();
            var predicateFilter = new ExpressionFilterDefinition<T>(predicate);
            return new FilterDefinitionBuilder<T>().And(entityTypeFilter, predicateFilter);
        }

        private static FilterDefinition<T> CreateEntityTypeFilterDefinition()
        {
            var entityTypeFilter = new ExpressionFilterDefinition<T>(x => x.AggregateTypeName == typeof(T).FullName);
            return entityTypeFilter;
        }
    }
}