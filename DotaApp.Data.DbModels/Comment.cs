using DotaApp.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotaApp.Data.DbModels
{
    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(10)]
        public string CommentMessage { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ItemId { get; set; }

        [Required]
        public virtual Item Item { get; set; }
    }
}
