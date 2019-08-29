using DotaApp.Services.Dtos.Comments;
using System.Collections.Generic;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface IAdminService
    {
        void DeleteCommentById(int id);

        ICollection<CommentsReviewDto> Review();

        void Approve(int id);

        void Reject(int id);
    }
}
