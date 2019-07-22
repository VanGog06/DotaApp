using DotaApp.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace DotaApp.Data.Seeding
{
    public static class ModelBuilderExtensions
    {
        private const string ADMIN_ROLE = "Admin";
        private const string USER_ROLE = "User";
        private const string ADMIN_PASSWORD = "123456";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(new []
                {
                    new IdentityRole { Id = 1, Name = ADMIN_ROLE },
                    new IdentityRole { Id = 2, Name = USER_ROLE }
                });

            CreatePasswordHash(ADMIN_PASSWORD, out var passwordHash, out var passwordSalt);

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = ADMIN_ROLE.ToLower(),
                    Email = "admin@dota.app",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });

            modelBuilder.Entity<UserRole>()
                .HasData(new[]
                {
                    new UserRole { RoleId = 1, UserId = 1 }
                });
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
