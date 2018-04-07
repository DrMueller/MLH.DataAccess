using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers
{
    public interface IMongoClientFactory
    {
        MongoClient Create();
    }
}