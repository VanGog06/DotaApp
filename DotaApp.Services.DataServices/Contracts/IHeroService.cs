using DotaApp.Services.Dtos.Heroes;
using System.Collections.Generic;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface IHeroService
    {
        ICollection<HeroCardDto> GetAll();

        HeroDto GetById(int id);
    }
}
