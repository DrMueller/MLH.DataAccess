using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using Mmu.Mlh.LanguageExtensions.Areas.Specifications;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<IReadOnlyCollection<T>> LoadAsync(ISpecification<T> spec);

        Task<T> LoadByIdAsync(string id);

        Task<T> LoadSingleAsync(ISpecification<T> spec);

        Task<T> SaveAsync(T aggregateRoot);
    }
}