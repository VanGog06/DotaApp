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

        public DbSet<Ability> Abilities { get; set; }

        public DbSet<AbilityAttribute> AbilityAttributes { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemAttribute> ItemAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();

            builder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Entity<HeroRole>()
                .HasKey(hr => new { hr.HeroId, hr.RoleId });

            builder.Entity<Hero>()
                .HasMany(h => h.Abilities)
                .WithOne(a => a.Hero);

            builder.Entity<Ability>()
                .HasMany(a => a.AbilityAttributes)
                .WithOne(aa => aa.Ability);

            builder.Entity<Item>()
                .HasMany(i => i.ItemAttributes)
                .WithOne(ia => ia.Item);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
