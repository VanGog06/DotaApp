using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Items
{
    public class ItemCardDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
