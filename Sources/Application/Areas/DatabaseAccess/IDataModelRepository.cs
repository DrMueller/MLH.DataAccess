﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess
{
    /// <summary>
    ///     This Interface provides the low level implementation to the data store, also using expressions for performant
    ///     access.
    ///     For example, the MongoDbDataModelRepository implements this one
    /// </summary>
    public interface IDataModelRepository<T, TId>
        where T : DataModelBase<TId>
    {
        Task DeleteAsync(TId id);

        Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate);

        Task<T> LoadSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> SaveAsync(T dataModelBase);
    }
}