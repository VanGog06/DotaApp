using DotaApp.Data.Common;
using System.Collections.Generic;

namespace DotaApp.Data.DbModels
{
    public class Item : BaseModel<int>
    {
        public Item()
        {
            this.ItemAttributes = new HashSet<ItemAttribute>();
            this.Comments = new HashSet<Comment>();
        }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Lore { get; set; }

        public virtual ICollection<ItemAttribute> ItemAttributes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
