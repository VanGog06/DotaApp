﻿using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;

namespace DotaApp.Services.DataServices
{
    public class CommentService : ICommentService
    {
        private readonly DotaAppContext context;
        

        public CommentService(DotaAppContext context)
        {
            this.context = context;
        }

        public int AddComment(AddCommentDto addComment)
        {
            var item = this.context.Items
                .FirstOrDefault(i => i.Id == addComment.ItemId);

            if (item == null)
            {
                throw new DotaException(Constants.InvalidOperation);
            }

            var comment = new Comment
            {
                CommentMessage = HtmlEncoder.Default.Encode(addComment.Comment),
                Username = addComment.Username,
                Item = item,
                ItemId = item.Id
            };

            this.context.Comments.Add(comment);
            this.context.SaveChanges();

            return comment.Id;
        }

        public ICollection<CommentDto> All(int itemId)
        {
            var dbComments = this.context.Comments
                .Where(c => c.ItemId == itemId && !c.IsPending && c.IsApproved)
                .ToList();

            var comments = new List<CommentDto>();

            foreach (var dbComment in dbComments)
            {
                DateTime dbCreatedOn = dbComment.CreatedOn;
                DateTime dbCreatedOnAsUTC = DateTime.SpecifyKind(dbCreatedOn, DateTimeKind.Utc);
                DateTime createdOnLocal = dbCreatedOnAsUTC.ToLocalTime();

                var comment = new CommentDto
                {
                    Id = dbComment.Id,
                    Comment = dbComment.CommentMessage,
                    Username = dbComment.Username,
                    CreatedOn = createdOnLocal
                };

                comments.Add(comment);
            }

            return comments
                .OrderByDescending(c => c.CreatedOn)
                .ToList();
        }
    }
}
