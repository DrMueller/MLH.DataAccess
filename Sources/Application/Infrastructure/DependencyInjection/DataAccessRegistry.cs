using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers.Implementation;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Implementation;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services.CoreMappings;
using Mmu.Mlh.DataAccess.Areas.DataMapping.Services.Implementation;
using Mmu.Mlh.DataAccess.Areas.IdGeneration;
using Mmu.Mlh.DataAccess.Areas.IdGeneration.Implementation;
using StructureMap;

namespace Mmu.Mlh.DataAccess.Infrastructure.DependencyInjection
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AddAllTypesOf<IDataMapper>();
                    scanner.WithDefaultConventions();
                });

            For<IDataMapper>().Use<DataModelBaseDataMapper>();
            For<IDataMappingInitializationService>().Use<DataMappingInitializationService>().Singleton();
            For<IEntityIdFactory>().Use<EntityIdFactory>().Singleton();

            For<IMongoClientFactory>().Use<MongoClientFactory>().Singleton();
            For<IMongoDbAccess>().Use<MongoDbAccess>().Singleton();
            For(typeof(IMongoDbFilterDefinitionFactory<>)).Use(typeof(MongoDbFilterDefinitionFactory<>)).Singleton();
            For(typeof(IDataModelRepository<>)).Use(typeof(DataModelRepository<>));
        }
    }
}