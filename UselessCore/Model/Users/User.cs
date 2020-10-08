using Microsoft.AspNetCore.Identity;

namespace UselessCore.Model.Users
{
    public class User : IdentityUser
    {
        public int? AvatarIconId { get; set; }
        public string DisplayName { get; set; }
    }
}
