using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Model.Users;

namespace UselessCMS.Models.Roles
{
    public static class Utilities
    {
        public static UserRoleViewModel Translate(this User user)
        {
            return new UserRoleViewModel
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }
    }
}
