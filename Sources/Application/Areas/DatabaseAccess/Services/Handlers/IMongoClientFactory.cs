using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers
{
    internal interface IMongoClientFactory
    {
        MongoClient Create();
    }
}