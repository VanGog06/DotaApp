using System.Collections.Generic;
using System.Linq;
using DotaApp.Data;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Items;

namespace DotaApp.Services.DataServices
{
    public class ItemService : IItemService
    {
        private readonly DotaAppContext context;

        public ItemService(DotaAppContext context)
        {
            this.context = context;
        }

        public ICollection<ItemCardDto> GetAll()
        {
            var items = this.context.Items
                .Where(i => !string.IsNullOrEmpty(i.Name))
                .Select(i => new ItemCardDto
                {
                    Id = i.Id,
                    Image = i.Image,
                    Name = i.Name
                })
                .ToList();

            return items;
        }
    }
}
