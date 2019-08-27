using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Services.DataServices.Contracts;
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
    }
}
