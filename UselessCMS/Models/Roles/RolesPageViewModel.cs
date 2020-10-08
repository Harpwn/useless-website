using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Enums;

namespace UselessCMS.Models.Roles
{
    public class RolesPageViewModel : MasterViewModel
    {
        public Dictionary<RoleType, IEnumerable<UserRoleViewModel>> UserRoles { get; set; } = new Dictionary<RoleType, IEnumerable<UserRoleViewModel>>();
    }
}
