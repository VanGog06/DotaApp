using DotaApp.Services.Dtos.Abilities;
using DotaApp.Services.Dtos.Roles;
using System.Collections.Generic;

namespace DotaApp.Services.Dtos.Heroes
{
    public class HeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PrimaryAttribute { get; set; }

        public string AttackType { get; set; }

        public string Image { get; set; }

        public string Icon { get; set; }

        public int BaseHealth { get; set; }

        public double? BaseHealthRegen { get; set; }

        public int BaseMana { get; set; }

        public double BaseManaRegen { get; set; }

        public double BaseArmor { get; set; }

        public int BaseMr { get; set; }

        public int BaseAttackMin { get; set; }

        public int BaseAttackMax { get; set; }

        public int BaseStrength { get; set; }

        public int BaseAgility { get; set; }

        public int BaseIntellect { get; set; }

        public double StrengthGain { get; set; }

        public double AgilityGain { get; set; }

        public double IntellectGain { get; set; }

        public int AttackRange { get; set; }

        public int ProjectileSpeed { get; set; }

        public double AttackRate { get; set; }

        public int MoveSpeed { get; set; }

        public double TurnRate { get; set; }

        public int Legs { get; set; }

        public virtual ICollection<RoleDto> Roles { get; set; }

        public virtual ICollection<AbilityDto> Abilities { get; set; }
    }
}
