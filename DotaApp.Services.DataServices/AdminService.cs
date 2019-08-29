using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Comments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotaApp.Services.DataServices
{
    public class AdminService : IAdminService
    {
        private readonly DotaAppContext context;

        public AdminService(DotaAppContext context)
        {
            this.context = context;
        }

        public void DeleteCommentById(int id)
        {
            var comment = this.context.Comments
                .FirstOrDefault(c => c.Id == id);

            if (comment == null)
            {
                throw new DotaException(Constants.InvalidOperation);
            }

            this.context.Comments.Remove(comment);
            this.context.SaveChanges();
        }

        public ICollection<CommentsReviewDto> Review()
        {
            var dbComments = this.context.Comments
                .Include(c => c.Item)
                .Where(c => !c.IsApproved && c.IsPending)
                .ToList();

            var comments = new List<CommentsReviewDto>();

            foreach (var dbComment in dbComments)
            {
                DateTime dbCreatedOn = dbComment.CreatedOn;
                DateTime dbCreatedOnAsUTC = DateTime.SpecifyKind(dbCreatedOn, DateTimeKind.Utc);
                DateTime createdOnLocal = dbCreatedOnAsUTC.ToLocalTime();

                var comment = new CommentsReviewDto
                {
                    Id = dbComment.Id,
                    Comment = dbComment.CommentMessage,
                    Username = dbComment.Username,
                    CreatedOn = createdOnLocal,
                    ItemId = dbComment.ItemId,
                    ItemName = dbComment.Item.Name  
                };

                comments.Add(comment);
            }

            return comments;
        }
    }
}
