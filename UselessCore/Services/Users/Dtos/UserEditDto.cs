namespace UselessCore.Services.Users.Dtos
{
    public class UserDto : BaseUserDto
    {
        public string Email { get; set; }
        public int? AvatarIconId { get; set; }
        public string DisplayName { get; set; }

    }
}
