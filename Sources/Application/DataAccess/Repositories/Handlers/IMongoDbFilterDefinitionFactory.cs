using System;
using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories.Handlers
{
    public interface IMongoDbFilterDefinitionFactory<T>
        where T : AggregateRoot
    {
        FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate);
    }
}