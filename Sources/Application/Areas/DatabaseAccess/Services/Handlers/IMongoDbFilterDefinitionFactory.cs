using System;
using System.Linq.Expressions;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers
{
    internal interface IMongoDbFilterDefinitionFactory<T>
        where T : DataModelBase
    {
        FilterDefinition<T> CreateFilterDefinition(Expression<Func<T, bool>> predicate);
    }
}