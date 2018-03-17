using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}