namespace DotaApp.Data.DbModels
{
    public class UserRole
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int RoleId { get; set; }

        public IdentityRole Role { get; set; }
    }
}
