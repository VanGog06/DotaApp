using DotaApp.Services.Dtos.Items;
using System.Collections.Generic;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface IItemService
    {
        ICollection<ItemCardDto> GetAll();
    }
}
