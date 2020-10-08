using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Users;
using UselessCore.Services.Users.Dtos;

namespace UselessCore.Services.Users
{
    public class UserActionResult : ServiceActionResult
    {
        public UserActionResult(UserDto user, IdentityResult result): base(result)
        {
            User = user;
        }

        public UserActionResult(string error) : base(error) { }

        public UserActionResult(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}
