using MongoDB.Bson;

namespace Mmu.Mlh.DataAccess.Areas.IdGeneration.Implementation
{
    internal class EntityIdFactory : IEntityIdFactory
    {
        public string CreateEntityId() => ObjectId.GenerateNewId().ToString();
    }
}