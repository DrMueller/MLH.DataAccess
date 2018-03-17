using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories.Handlers
{
    public interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot;
    }
}