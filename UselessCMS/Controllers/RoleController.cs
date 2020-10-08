using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UselessCMS.Models.Roles;
using UselessCore.Enums;
using UselessCore.Model.Users;
using UselessCore.Web.Auth;

namespace UselessCMS.Controllers
{
    [Authorize(Roles = RoleHelpers.SuperAdminOnly)]
    public class RoleController : MasterController
    {
        private UserManager<User> _userManager;

        public RoleController(UserManager<User> userManager, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new RolesPageViewModel();

            foreach (RoleType role in (RoleType[])Enum.GetValues(typeof(RoleType)))
            {
                if (role != RoleType.Standard)
                {
                    var users = await _userManager.GetUsersInRoleAsync(role.ToString());
                    model.UserRoles.Add(role, users.Select(u => u.Translate()));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> AddRoleToUser(string userName, string role)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return RedirectToAction("Index", "Role");
        }

        public async Task<IActionResult> RemoveRoleFromUser(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            return RedirectToAction("Index", "Role");
        }
    }
}
