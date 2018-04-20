using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers.Implementation
{
    internal class MongoDbAccess : IMongoDbAccess
    {
        private readonly DatabaseSettings _databaseSettings;
        private readonly IMongoClientFactory _mongoClientFactory;

        public MongoDbAccess(
            IMongoClientFactory mongoClientFactory,
            IDatabaseSettingsProvider databaseSettingsProvider)
        {
            _mongoClientFactory = mongoClientFactory;
            _databaseSettings = databaseSettingsProvider.ProvideDatabaseSettings();
        }

        public IMongoCollection<T> GetDatabaseCollection<T>()
            where T : DataModelBase
        {
            var db = GetDatabase();
            var result = db.GetCollection<T>(_databaseSettings.CollectionName);

            return result;
        }

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = _mongoClientFactory.Create();
            var database = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            return database;
        }
    }
}