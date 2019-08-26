using DotaApp.Services.Dtos.Comments;
using System.Collections.Generic;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface ICommentService
    {
        ICollection<CommentDto> All(int itemId);

        void AddComment(AddCommentDto addComment);
    }
}
