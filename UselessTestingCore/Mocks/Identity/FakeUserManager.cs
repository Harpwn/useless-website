using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Model.Users;

namespace UselessTestingCore.Mocks.Identity
{
    public class FakeUserManager : UserManager<User>
    {
        private const string CorrectPassword = "password";

        public User CurrentUser { get; set; } = new User { Id = "1", UserName = "John" };
        public RoleType CurrentRole { get; set; } = RoleType.Administrator;

        public FakeUserManager()
            : base(new Mock<IUserStore<User>>().Object,
              new Mock<IOptions<IdentityOptions>>().Object,
              new Mock<IPasswordHasher<User>>().Object,
              new IUserValidator<User>[0],
              new IPasswordValidator<User>[0],
              new Mock<ILookupNormalizer>().Object,
              new Mock<IdentityErrorDescriber>().Object,
              new Mock<IServiceProvider>().Object,
              new Mock<ILogger<UserManager<User>>>().Object)
        {
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<User> GetUserAsync(ClaimsPrincipal principal)
        {
            return Task.FromResult(CurrentUser);
        }

        public override Task<bool> IsInRoleAsync(User user, string role)
        {
            return Task.FromResult(CurrentRole.ToString() == role);
        }

        public override Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return Task.FromResult(new IdentityResult());
        }

        public override Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }

        public override Task<User> FindByNameAsync(string userName)
        {
            if (userName == CurrentUser.UserName)
                return Task.FromResult(CurrentUser);
            else
                return Task.FromResult((User)null);
        }

        public override Task<User> FindByIdAsync(string userId)
        {
            if (userId == CurrentUser.Id)
                return Task.FromResult(CurrentUser);
            else
                return Task.FromResult((User)null);
        }

        public override Task<IdentityResult> UpdateAsync(User user)
        {
            return Task.FromResult(new IdentityResult());
        }

        public override Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
            IList<User> users = new List<User> { CurrentUser };
            return Task.FromResult(users);
        }

        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return Task.FromResult(password == CorrectPassword);
        }

        public override Task<IdentityResult> DeleteAsync(User user)
        {
            return Task.FromResult(new IdentityResult() { });
        }

        public override Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return Task.FromResult(new IdentityResult() { });
        }
    }
}
