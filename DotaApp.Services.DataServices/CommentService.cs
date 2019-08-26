using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Comments;
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

        public void AddComment(AddCommentDto addComment)
        {
            var item = this.context.Items
                .FirstOrDefault(i => i.Id == addComment.ItemId);

            if (item == null)
            {
                throw new DotaException("Item cannot be null");
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
        }
    }
}
