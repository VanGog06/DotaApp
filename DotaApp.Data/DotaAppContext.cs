using DotaApp.Data.DbModels;
using DotaApp.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace DotaApp.Data
{
    public class DotaAppContext : DbContext
    {
        public DotaAppContext(DbContextOptions<DotaAppContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<IdentityRole> IdentityRoles { get; set; }

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();

            builder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Entity<HeroRole>()
                .HasKey(hr => new { hr.HeroId, hr.RoleId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
