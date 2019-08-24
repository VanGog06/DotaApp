using DotaApp.Data.Common;

namespace DotaApp.Data.DbModels
{
    public class AbilityAttribute : BaseModel<int>
    {
        public string Key { get; set; }

        public string Header { get; set; }

        public string Value { get; set; }

        public bool Generated { get; set; }

        public int AbilityId { get; set; }

        public virtual Ability Ability { get; set; }
    }
}
