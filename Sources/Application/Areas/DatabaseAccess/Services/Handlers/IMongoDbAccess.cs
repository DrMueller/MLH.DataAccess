using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using MongoDB.Driver;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services.Handlers
{
    internal interface IMongoDbAccess
    {
        IMongoCollection<T> GetDatabaseCollection<T>()
            where T : DataModelBase;
    }
}