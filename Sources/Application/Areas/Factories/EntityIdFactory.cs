using Mmu.Mlh.DomainExtensions.Areas.Factories;
using MongoDB.Bson;

namespace Mmu.Mlh.DataAccess.Areas.Factories
{
    internal class EntityIdFactory : IEntityIdFactory<string>
    {
        public string CreateEntityId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}