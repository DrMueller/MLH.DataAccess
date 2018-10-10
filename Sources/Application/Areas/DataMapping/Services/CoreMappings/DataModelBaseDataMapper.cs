using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using MongoDB.Bson.Serialization;

namespace Mmu.Mlh.DataAccess.Areas.DataMapping.Services.CoreMappings
{
    internal class DataModelBaseDataMapper : IDataMapper
    {
        public void InitializeDataMapping()
        {
            var dataModelBaseType = typeof(DataModelBase<>);

            var baseMap = new BsonClassMap(dataModelBaseType);
            baseMap.AutoMap();
            baseMap.MapIdMember(dataModelBaseType.GetProperty("Id"));
            baseMap.MapIdMember(dataModelBaseType.GetProperty("DataModelTypeName"));

            BsonClassMap.RegisterClassMap(baseMap);
        }
    }
}