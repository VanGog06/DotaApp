using DotaApp.Data.Common;
using System.Collections.Generic;

namespace DotaApp.Data.DbModels
{
    public class Hero : BaseModel<int>
    {
        public Hero()
        {
            this.Roles = new HashSet<HeroRole>();
            this.Abilities = new HashSet<Ability>();
        }

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

        public virtual ICollection<HeroRole> Roles { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }
    }
}
