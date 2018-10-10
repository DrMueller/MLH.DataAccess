using StructureMap;

namespace Mmu.Mlh.DataAccess.Infrastructure.DependencyInjection
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DataAccessRegistry>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}