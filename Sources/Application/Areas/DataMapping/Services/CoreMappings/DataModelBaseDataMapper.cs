using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using MongoDB.Bson.Serialization;

namespace Mmu.Mlh.DataAccess.Areas.DataMapping.Services.CoreMappings
{
    internal class DataModelBaseDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            BsonClassMap.RegisterClassMap<DataModelBase>(
                f =>
                {
                    f.AutoMap();
                    f.MapIdMember(c => c.Id);
                    f.MapMember(c => c.DataModelTypeName);
                });
        }
    }
}