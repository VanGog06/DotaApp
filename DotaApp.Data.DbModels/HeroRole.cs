namespace DotaApp.Data.DbModels
{
    public class HeroRole
    {
        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
