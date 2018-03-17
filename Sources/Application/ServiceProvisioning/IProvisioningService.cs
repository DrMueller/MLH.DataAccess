using System.Collections.Generic;

namespace Mmu.Mlh.DataAccess.ServiceProvisioning
{
    public interface IProvisioningService
    {
        IReadOnlyCollection<T> GetAllServices<T>();

        T GetService<T>();
    }
}