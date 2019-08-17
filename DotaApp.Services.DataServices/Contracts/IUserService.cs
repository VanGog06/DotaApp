using DotaApp.Services.Dtos.Users;

namespace DotaApp.Services.DataServices.Contracts
{
    public interface IUserService
    {
        UserWithoutPasswordDto Authenticate(UsernamePasswordDto usernamePasswordDto);

        UserDto Register(UserDto userDto);
    }
}
