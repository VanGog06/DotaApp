namespace DotaApp.Data.DbModels
{
    public class HeroRole
    {
        public int HeroId { get; set; }

        public virtual Hero Hero { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
