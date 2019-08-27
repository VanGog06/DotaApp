using DotaApp.Data;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos;
using DotaApp.Services.Dtos.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using DotaApp.Data.DbModels;
using DotaApp.Common;
using DotaApp.Data.Common;

namespace DotaApp.Services.DataServices
{
    public class UserService : IUserService
    {
        private readonly DotaAppContext context;
        private readonly AppSettings appSettings;

        public UserService(DotaAppContext context, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this.appSettings = appSettings.Value;
        }

        public UserWithoutPasswordDto Authenticate(UsernamePasswordDto dto)
        {
            var user = this.context.Users.SingleOrDefault(u => u.Username == dto.Username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            claims = claims.Concat(user.Roles.Select(r => new Claim(ClaimTypes.Role, r.Role.Name))).ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    claims
                ),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userDto = new UserWithoutPasswordDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };

            return userDto;
        }

        public UserDto Register(UserDto userDto)
        {
            if (this.context.Users.Any(x => x.Username == userDto.Username))
                throw new DotaException(Constants.UsernameTaken);

            CreatePasswordHash(userDto.Password, out var passwordHash, out var passwordSalt);

            var userRole = this.context.IdentityRoles.FirstOrDefault(ur => ur.Name == "User");

            var user = new User
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Username = userDto.Password,
                Roles = new List<UserRole> { new UserRole { RoleId = userRole.Id } }
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return userDto;
        }

        public void Update(UpdateUserDto profile)
        {
            var dbUser = this.context.Users
                .FirstOrDefault(u => u.Username == profile.Username);

            if (dbUser == null)
            {
                throw new DotaException(Constants.UserNotFound);
            }

            if (!VerifyPasswordHash(profile.CurrentPassword, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                throw new DotaException(Constants.ProvidedPasswordIsIncorrect);
            }

            CreatePasswordHash(profile.NewPassword, out var newPasswordHash, out var newPasswordSalt);

            dbUser.PasswordHash = newPasswordHash;
            dbUser.PasswordSalt = newPasswordSalt;

            this.context.Users.Update(dbUser);
            this.context.SaveChanges();
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

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
