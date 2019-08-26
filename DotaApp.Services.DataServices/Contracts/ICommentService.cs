using DotaApp.Services.Dtos.Comments;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface ICommentService
    {
        void AddComment(AddCommentDto addComment);
    }
}
