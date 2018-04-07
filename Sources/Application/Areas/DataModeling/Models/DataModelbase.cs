namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Models
{
    public abstract class DataModelBase
    {
        public string DataModelTypeName
        {
            get
            {
                return GetType().FullName;
            }
        }

        public string Id { get; set; }
    }
}