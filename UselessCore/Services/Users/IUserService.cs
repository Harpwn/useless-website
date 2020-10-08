using System.Threading.Tasks;
using UselessCore.Services.Users.Dtos;

namespace UselessCore.Services.Users
{
    public interface IUserService
    {
        Task<UserActionResult> AuthenticateAsync(AuthUserDto dto);
        Task<ServiceActionResult> CreateAsync(RegisterUserDto dto);
        Task<UserActionResult> GetByIDAsync(string id);
        Task<UserActionResult> UpdateAsync(UserDto dto);
        Task<ServiceActionResult> ChangePasswordAsync(ChangePasswordDto dto);
        Task<ServiceActionResult> DeleteAsync(string id);
    }
}
