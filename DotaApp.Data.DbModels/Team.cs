using DotaApp.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Data.DbModels
{
    public class Team : BaseModel<int>
    {
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
