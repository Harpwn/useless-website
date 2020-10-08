using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UselessAPI.Helpers;
using UselessCore.Services.Users;
using UselessAPI.Model.Users;
using UselessCore.Services.Users.Dtos;
using UselessCore.Services;

namespace UselessAPI.Controllers
{
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;


        public UsersController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthUserDto userDto)
        {
            var result = await _userService.AuthenticateAsync(userDto);
            return GetAuthenticatedActionResult(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserDto userDto)
        {
            var result = await _userService.CreateAsync(userDto);
            if (!result.Succeeded)
                return GetActionResult(result);

            var authResult = await _userService.AuthenticateAsync(userDto);
            return GetAuthenticatedActionResult(authResult);
        }

        [HttpPost("profile")]
        public async Task<IActionResult> Profile()
        {
            var result = await _userService.GetByIDAsync(GetUserId());
            return GetActionResult(result);
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordDto changePasswordDto)
        {
            var result = await _userService.ChangePasswordAsync(changePasswordDto);
            return GetActionResult(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody]string userId)
        {
            var applicationUserId = GetUserId();

            if (applicationUserId != userId)
                return BadRequest(new { message = "You cannot delete another user" });

            var result = await _userService.DeleteAsync(userId);
            return GetActionResult(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]UserDto userDto)
        {
            var applicationUserId = GetUserId();

            if (applicationUserId != userDto.Id)
                return BadRequest(new { message = "You cannot update another user" });
            
            var updatedUser = await _userService.UpdateAsync(userDto);

            return GetActionResult(updatedUser);
        }

        private string GetJWTToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private IActionResult GetActionResult(ServiceActionResult result)
        {
            if (result.Succeeded)
            {
                return Ok(new { });
            }
            else
            {
                return BadRequest(new { message = result.GetErrorsMessage() });
            }
        }
        private IActionResult GetActionResult(UserActionResult result, string jwt = null)
        {
            if (result.Succeeded)
            {
                var user = new User
                {
                    Id = result.User.Id,
                    Name = result.User.UserName,
                    AvatarIconId = result.User.AvatarIconId,
                    DisplayName = result.User.DisplayName
                };

                return Ok(new { user, jwt });
            }
            else
            {
                return BadRequest(new { message = result.GetErrorsMessage() });
            }
        }
        private IActionResult GetAuthenticatedActionResult(UserActionResult result)
        {
            if (result.User != null)
            {
                var token = GetJWTToken(result.User);
                return GetActionResult(result,token);
            }
            else
            {
                return GetActionResult(result);
            }
        }

    }
}
