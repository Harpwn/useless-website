using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Enums;
using System.Linq;

namespace UselessCore.Web.Auth
{
    public static class RoleHelpers
    {
        public const string SuperAdminOnly = "SuperAdministrator";

        public const string Admin = "Administrator,SuperAdministrator";

        public const string Standard = "Standard,Administrator,SuperAdministrator";
    }
}
