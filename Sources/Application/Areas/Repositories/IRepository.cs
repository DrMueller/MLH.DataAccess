using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DataAccess.Areas.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<T> LoadByIdAsync(string id);

        Task<T> SaveAsync(T aggregateRoot);
    }
}