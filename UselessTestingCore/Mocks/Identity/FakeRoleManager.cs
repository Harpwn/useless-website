using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UselessCore.Model.Users;

namespace UselessTestingCore.Mocks.Identity
{
    public class FakeRoleManager : RoleManager<Role>
    {
        private List<string> _roles;

        public FakeRoleManager()
            : base(new Mock<IRoleStore<Role>>().Object,
                  new IRoleValidator<Role>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<ILogger<RoleManager<Role>>>().Object
            )
        {
            _roles = new List<string>();
        }

        public override Task<IdentityResult> CreateAsync(Role role)
        {
            _roles.Add(role.Name);
            return Task.FromResult(new IdentityResult());
        }

        public override Task<bool> RoleExistsAsync(string roleName)
        {
            return Task.FromResult(_roles.Contains(roleName));
        }
    }
}
