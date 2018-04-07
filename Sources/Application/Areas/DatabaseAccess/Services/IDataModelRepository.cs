﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services
{
    public interface IDataModelRepository<T>
        where T : DataModelBase
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate);

        Task<T> LoadSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> SaveAsync(T dataModelBase);
    }
}