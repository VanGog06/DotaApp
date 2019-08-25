using System.Collections.Generic;
using System.Linq;
using DotaApp.Data;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Items;
using Microsoft.EntityFrameworkCore;

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

        public ItemDto GetById(int id)
        {
            var item = this.context.Items
                .Include(i => i.ItemAttributes)
                .FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return null;
            }

            var itemDto = new ItemDto
            {
                Id = item.Id,
                Cost = item.Cost,
                Image = item.Image,
                Lore = item.Lore,
                Name = item.Name,
                ItemAttributes = item.ItemAttributes
                    .Select(ia => new ItemAttributeDto
                    {
                        Footer = ia.Footer,
                        Header = ia.Header,
                        Key = ia.Key,
                        Value = ia.Value
                    })
                    .ToList()
            };

            return itemDto;
        }
    }
}
