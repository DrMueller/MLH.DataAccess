using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess
{
    public interface IDataModelRepository<T, TId>
        where T : AggregateRootDataModel<TId>
    {
        Task DeleteAsync(TId id);

        Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate);

        Task<T> LoadSingleAsync(Expression<Func<T, bool>> predicate);

        Task<T> SaveAsync(T aggregateRootDataModel);
    }
}