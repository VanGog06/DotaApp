using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos;
using DotaApp.Services.Dtos.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DotaApp.Services.DataServices.Tests
{
    public class UserServiceTests
    {
        private IUserService userService;
        private IConfiguration configuration;

        private List<User> GetDummyUsers()
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return new List<User>
                {
                    new User { FirstName = "Pesho", LastName = "Peshov", Email = "pesho@abv.bg", Username = "pesho", PasswordHash =  hmac.ComputeHash(Encoding.UTF8.GetBytes("verySecurePassword")), PasswordSalt = hmac.Key },
                    new User { FirstName = "Gosho", LastName = "Goshov", Email = "gosho@abv.bg", Username = "gosho" },
                    new User { FirstName = "Stamat", LastName = "Stamatov", Email = "stamat@abv.bg", Username = "stamat" }
                };
            }
        }

        private List<IdentityRole> GetDummyUsersRoles()
        {
            var adminRole = new IdentityRole { Name = "Admin" };
            var userRole = new IdentityRole { Name = "User" };

            return new List<IdentityRole>
            {
                adminRole,
                userRole
            };
        }

        private void SeedUsers(DotaAppContext context)
        {
            context.Users.AddRange(this.GetDummyUsers());
            context.SaveChanges();
        }

        private void SeedRoles(DotaAppContext context)
        {
            context.IdentityRoles.AddRange(this.GetDummyUsersRoles());
            context.SaveChanges();
        }

        private IOptions<AppSettings> GetOptions()
        {
            AppSettings appSettings = new AppSettings() { Secret = "SuperDuperSecretStringSignKey" };
            IOptions<AppSettings> options = Options.Create(appSettings);

            return options;
        }

        [Fact]
        public void Register_WithDummyUsers_ShouldThrowErrorIfUsernameIsTaken()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedUsers(context);

            var options = this.GetOptions();

            this.userService = new UserService(context, options);

            var userDto = new UserDto
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Email = "pesho@abv.bg",
                Username = "pesho"
            };

            DotaException exception = Assert.Throws<DotaException>(() => this.userService.Register(userDto));

            Assert.Equal(Constants.UsernameTaken, exception.Message);
        }

        [Fact]
        public void Register_WithDummyUsersAndRoles_ShouldRegisterUserWithCorrectData()
        {
            var context = DotaAppContextInitializer.InitializeContext();

            this.SeedUsers(context);
            this.SeedRoles(context);

            var options = this.GetOptions();

            this.userService = new UserService(context, options);

            var userDto = new UserDto
            {
                FirstName = "Pesho2",
                LastName = "Peshov2",
                Email = "pesho2@abv.bg",
                Username = "pesho2",
                Password = "pesho2"
            };

            var expectedRegisteredUser = this.userService.Register(userDto);

            var expectedUsersLength = 4;
            var actualUsers = context.Users.ToList();

            Assert.Equal(expectedUsersLength, actualUsers.Count);

            var actualRegisteredUser = context.Users.Last();

            Assert.Equal(expectedRegisteredUser.Username, actualRegisteredUser.Username);
        }

        [Fact]
        public void Authenticate_WithDummyUsers_ShouldThrowErrorIfUserWithThatUsernameIsNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedUsers(context);

            var options = this.GetOptions();

            this.userService = new UserService(context, options);

            var usernamePasswordDto = new UsernamePasswordDto
            {
                Username = "Penka"
            };

            DotaException exception = Assert.Throws<DotaException>(() => this.userService.Authenticate(usernamePasswordDto));

            Assert.Equal(Constants.IncorrectUsernamePassword, exception.Message);
        }

        [Fact]
        public void Update_WithDummyUses_ShouldThrowErrorIfUserWithThatUsernameDoesNotExist()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedUsers(context);

            var options = this.GetOptions();

            this.userService = new UserService(context, options);

            var updateUserDto = new UpdateUserDto
            {
                Username = "Stoika"
            };

            DotaException exception = Assert.Throws<DotaException>(() => this.userService.Update(updateUserDto));

            Assert.Equal(Constants.UserNotFound, exception.Message);
        }
    }
}
