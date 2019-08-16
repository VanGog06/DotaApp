using DotaApp.Data.Common;
using Newtonsoft.Json;

namespace DotaApp.Data.ApiModels
{
    public class HeroDto : BaseModel<int>
    {
        [JsonProperty("localized_name")]
        public string Name { get; set; }

        [JsonProperty("primary_attr")]
        public string PrimaryAttribute { get; set; }

        [JsonProperty("attack_type")]
        public string AttackType { get; set; }

        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        [JsonProperty("img")]
        public string Image { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("base_health")]
        public int BaseHealth { get; set; }

        [JsonProperty("base_health_regen")]
        public double? BaseHealthRegen { get; set; }

        [JsonProperty("base_mana")]
        public int BaseMana { get; set; }

        [JsonProperty("base_mana_regen")]
        public double BaseManaRegen { get; set; }

        [JsonProperty("base_armor")]
        public double BaseArmor { get; set; }

        [JsonProperty("base_mr")]
        public int BaseMr { get; set; }

        [JsonProperty("base_attack_min")]
        public int BaseAttackMin { get; set; }

        [JsonProperty("base_attack_max")]
        public int BaseAttackMax { get; set; }

        [JsonProperty("base_str")]
        public int BaseStrength { get; set; }

        [JsonProperty("base_agi")]
        public int BaseAgility { get; set; }

        [JsonProperty("base_int")]
        public int BaseIntellect { get; set; }

        [JsonProperty("str_gain")]
        public double StrengthGain { get; set; }

        [JsonProperty("agi_gain")]
        public double AgilityGain { get; set; }

        [JsonProperty("int_gain")]
        public double IntellectGain { get; set; }

        [JsonProperty("attack_range")]
        public int AttackRange { get; set; }

        [JsonProperty("projectile_speed")]
        public int ProjectileSpeed { get; set; }

        [JsonProperty("attack_rate")]
        public double AttackRate { get; set; }

        [JsonProperty("move_speed")]
        public int MoveSpeed { get; set; }

        [JsonProperty("turn_rate")]
        public double TurnRate { get; set; }

        [JsonProperty("legs")]
        public int Legs { get; set; }
    }
}
