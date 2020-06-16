using Lamar;

namespace Mmu.Mlh.DataAccess.Infrastructure.DependencyInjection
{
    public class DataAccessRegistryCollection : ServiceRegistry
    {
        public DataAccessRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DataAccessRegistryCollection>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}