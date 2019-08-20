using System.Collections.Generic;
using System.Linq;
using DotaApp.Data;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Heroes;
using DotaApp.Services.Dtos.Roles;
using DotaApp.Services.Mapping;
using Microsoft.EntityFrameworkCore;

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

        public HeroDto GetById(int id)
        {
            var hero = this.context.Heroes
                .Include(h => h.Roles)
                .FirstOrDefault(h => h.Id == id);

            if (hero == null)
            {
                return null;
            }

            var heroDto = new HeroDto
            {
                Id = hero.Id,
                AgilityGain = hero.AgilityGain,
                AttackRange = hero.AttackRange,
                AttackRate = hero.AttackRate,
                AttackType = hero.AttackType,
                BaseAgility = hero.BaseAgility,
                BaseArmor = hero.BaseArmor,
                BaseAttackMax = hero.BaseAttackMax,
                BaseAttackMin = hero.BaseAttackMin,
                BaseHealth = hero.BaseHealth,
                BaseHealthRegen = hero.BaseHealthRegen,
                BaseIntellect = hero.BaseIntellect,
                BaseMana = hero.BaseMana,
                BaseManaRegen = hero.BaseManaRegen,
                BaseMr = hero.BaseMr,
                BaseStrength = hero.BaseStrength,
                Icon = hero.Icon,
                Image = hero.Image,
                IntellectGain = hero.IntellectGain,
                Legs = hero.Legs,
                MoveSpeed = hero.MoveSpeed,
                Name = hero.Name,
                PrimaryAttribute = hero.PrimaryAttribute,
                ProjectileSpeed = hero.ProjectileSpeed,
                StrengthGain = hero.StrengthGain,
                TurnRate = hero.TurnRate,
                Roles = hero.Roles
                    .Select(r => new RoleDto { Id = r.RoleId, Name = r.Role.Name })
                    .ToList()
            };

            return heroDto;
        }
    }
}
