using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.DataAccess.ServiceProvisioning;
using MongoDB.Bson.Serialization;

namespace Mmu.Mlh.DataAccess.DataAccess.DataMapping.Implementation
{
    public class DataMappingInitializationService : IDataMappingInitializationService
    {
        private readonly IReadOnlyCollection<IDataMapper> _dataMappers;
        private readonly object _lock = new object();

        public DataMappingInitializationService(IProvisioningService provisioningService) => _dataMappers = provisioningService.GetAllServices<IDataMapper>();

        public void AssureMappingsAreInitialized()
        {
            if (BsonClassMap.GetRegisteredClassMaps().Any())
            {
                return;
            }

            lock (_lock)
            {
                if (BsonClassMap.GetRegisteredClassMaps().Any())
                {
                    return;
                }

                foreach (var dataMapper in _dataMappers)
                {
                    dataMapper.InitializeDataMapping();
                }
            }
        }
    }
}