namespace DotaApp.Data.DbModels
{
    public class UserRole
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int RoleId { get; set; }

        public virtual IdentityRole Role { get; set; }
    }
}
