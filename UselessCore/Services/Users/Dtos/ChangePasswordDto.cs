using System;
using System.Collections.Generic;
using System.Text;

namespace UselessCore.Services.Users.Dtos
{
    public class ChangePasswordDto : AuthUserDto
    {
        public string NewPassword { get; set; }
    }
}
