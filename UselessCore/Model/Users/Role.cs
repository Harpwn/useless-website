using Microsoft.AspNetCore.Identity;
using UselessCore.Enums;

namespace UselessCore.Model.Users
{
    public class Role : IdentityRole
    {
        public RoleType Type { get; set; }
    }
}
