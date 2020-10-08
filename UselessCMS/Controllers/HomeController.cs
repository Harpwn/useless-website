using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UselessCMS.Models;
using UselessCMS.Models.Home;
using UselessCore.Enums;
using UselessCore.Model.Users;

namespace UselessCMS.Controllers
{
    public class HomeController : MasterController
    {
        private UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);

            model.Role = await _userManager.IsInRoleAsync(user, RoleType.SuperAdministrator.ToString()) ? RoleType.SuperAdministrator : RoleType.Administrator;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
