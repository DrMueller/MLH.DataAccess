namespace Mmu.Mlh.DataAccess.DataAccess.Settings
{
    public class MongoDbSettings
    {
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public bool UseSsl { get; set; }
    }
}