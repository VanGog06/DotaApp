using DotaApp.Data.Common;

namespace DotaApp.Data.DbModels
{
    public class ItemAttribute : BaseModel<int>
    {
        public string Key { get; set; }

        public string Header { get; set; }

        public string Value { get; set; }

        public string Footer { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
