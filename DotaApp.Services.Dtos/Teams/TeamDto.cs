using System;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Services.Dtos.Teams
{
    public class TeamDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public int Wins { get; set; }

        [Required]
        public int Losses { get; set; }

        [Required]
        public DateTime LastMatchTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }
    }
}
