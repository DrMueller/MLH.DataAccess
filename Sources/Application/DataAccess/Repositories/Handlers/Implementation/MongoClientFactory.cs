using System.Security.Authentication;
using Mmu.Mlh.DataAccess.DataAccess.DataMapping;
using Mmu.Mlh.DataAccess.DataAccess.Settings;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.DataAccess.Repositories.Handlers.Implementation
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly MongoDbSettings _mongoDbSettings;

        public MongoClientFactory(IMongoDbSettingsProvider mongoDbSettingsProvider, IDataMappingInitializationService dataMappingInitializationService)
        {
            dataMappingInitializationService.AssureMappingsAreInitialized();
            _mongoDbSettings = mongoDbSettingsProvider.ProvideSettings();
        }

        public MongoClient Create()
        {
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(_mongoDbSettings.Host, _mongoDbSettings.Port),
                UseSsl = _mongoDbSettings.UseSsl
            };

            if (clientSettings.UseSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }

            var identity = new MongoInternalIdentity(_mongoDbSettings.DatabaseName, _mongoDbSettings.UserName);
            var evidence = new PasswordEvidence(_mongoDbSettings.Password);
            clientSettings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            var mongoClient = new MongoClient(clientSettings);
            return mongoClient;
        }
    }
}