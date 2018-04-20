using System.Security.Authentication;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers.Implementation
{
    internal class MongoClientFactory : IMongoClientFactory
    {
        private readonly DatabaseSettings _databaseSettings;

        public MongoClientFactory(IDatabaseSettingsProvider databaseSettingsProvider, IDataMappingInitializationService dataMappingInitializationService)
        {
            dataMappingInitializationService.AssureMappingsAreInitialized();
            _databaseSettings = databaseSettingsProvider.ProvideDatabaseSettings();
        }

        public MongoClient Create()
        {
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(_databaseSettings.Host, _databaseSettings.Port),
                UseSsl = _databaseSettings.UseSsl
            };

            if (clientSettings.UseSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }

            var identity = new MongoInternalIdentity(_databaseSettings.DatabaseName, _databaseSettings.UserName);
            var evidence = new PasswordEvidence(_databaseSettings.Password);
            clientSettings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            var mongoClient = new MongoClient(clientSettings);
            return mongoClient;
        }
    }
}