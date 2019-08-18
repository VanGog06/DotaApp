using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Heroes
{
    public class HeroCardDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AttackType { get; set; }
    }
}
