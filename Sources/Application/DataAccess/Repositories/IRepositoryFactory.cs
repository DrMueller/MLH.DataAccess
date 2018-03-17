using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>()
            where T : AggregateRoot;
    }
}