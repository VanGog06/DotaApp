using System.Collections.Generic;
using System.Linq;
using DotaApp.Data;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Heroes;

namespace DotaApp.Services.DataServices
{
    public class HeroService : IHeroService
    {
        private readonly DotaAppContext context;

        public HeroService(DotaAppContext context)
        {
            this.context = context;
        }

        public ICollection<HeroCardDto> GetAll()
        {
            var heroes = this.context.Heroes
                .Select(h => new HeroCardDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    ImageUrl = h.Image,
                    AttackType = h.AttackType
                })
                .ToList();

            return heroes;
        }
    }
}
