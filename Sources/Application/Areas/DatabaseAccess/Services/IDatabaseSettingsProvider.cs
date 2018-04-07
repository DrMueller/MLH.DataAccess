using Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Models;

namespace Mmu.Mlh.DataAccess.Areas.DatabaseAccess.Services
{
    public interface IDatabaseSettingsProvider
    {
        DatabaseSettings ProvideSettings();
    }
}