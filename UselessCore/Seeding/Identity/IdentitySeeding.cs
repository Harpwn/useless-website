using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Enums;
using UselessCore.Model.Users;

namespace UselessCore.Seeding.Identity
{
    public static class IdentitySeeding
    {
        public static void SeedData(UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("SuperAdmin").Result == null)
            {
                User user = new User();
                user.UserName = "SuperAdmin";

                IdentityResult result = userManager.CreateAsync(user, "tjAaEr318*FX").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,RoleType.SuperAdministrator.ToString()).Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            foreach (var roleEnum in (RoleType[])Enum.GetValues(typeof(RoleType)))
            {
                var roleName = roleEnum.ToString();

                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    Role role = new Role();
                    role.Name = roleName;
                    role.Type = roleEnum;
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                }
            }
        }
    }
}
