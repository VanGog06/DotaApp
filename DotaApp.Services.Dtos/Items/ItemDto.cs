using System.Collections.Generic;

namespace DotaApp.Services.Dtos.Items
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Lore { get; set; }

        public ICollection<ItemAttributeDto> ItemAttributes { get; set; }
    }
}
