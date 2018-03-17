namespace Mmu.Mlh.DataAccess.DataAccess.Settings
{
    public interface IMongoDbSettingsProvider
    {
        MongoDbSettings ProvideSettings();
    }
}