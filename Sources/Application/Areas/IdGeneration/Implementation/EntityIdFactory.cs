using MongoDB.Bson;

namespace Mmu.Mlh.DataAccess.Areas.IdGeneration.Implementation
{
    public class EntityIdFactory : IEntityIdFactory
    {
        public string CreateEntityId() => ObjectId.GenerateNewId().ToString();
    }
}