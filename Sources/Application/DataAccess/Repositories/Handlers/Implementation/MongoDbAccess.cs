using Mmu.Mlh.DataAccess.DataAccess.Settings;
using Mmu.Mlh.LanguageExtensions.Areas.ModelAbstractions;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories.Handlers.Implementation
{
    public class MongoDbAccess : IMongoDbAccess
    {
        private readonly IMongoClientFactory _mongoClientFactory;
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoDbAccess(IMongoClientFactory mongoClientFactory, IMongoDbSettingsProvider mongoDbSettingsProvider)
        {
            _mongoClientFactory = mongoClientFactory;
            _mongoDbSettings = mongoDbSettingsProvider.ProvideSettings();
        }

        public IMongoCollection<T> GetDatabaseCollection<T>()
            where T : AggregateRoot
        {
            var db = GetDatabase();
            var result = db.GetCollection<T>(_mongoDbSettings.CollectionName);

            return result;
        }

        private IMongoDatabase GetDatabase()
        {
            var mongoClient = _mongoClientFactory.Create();
            var database = mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);
            return database;
        }
    }
}