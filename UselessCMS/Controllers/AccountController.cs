using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UselessCMS.Models.Accounts;
using UselessCore.Enums;
using UselessCore.Model.Users;
using UselessCore.Web.Auth;

namespace UselessCMS.Controllers
{
    public class AccountController : MasterController
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login");

            return RedirectToAction("Manage");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Email = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RoleType.Standard.ToString());
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if(user != null)
                {
                    var isAdmin = await _userManager.IsInRoleAsync(user, RoleType.Administrator.ToString());
                    var isSuperAdmin = await _userManager.IsInRoleAsync(user, RoleType.SuperAdministrator.ToString());

                    if (isAdmin || isSuperAdmin)
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                        if (result.Succeeded)
                        {

                            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                            {
                                return Redirect(model.ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Only Administrators can access this part of the system");
                        return View(model);
                    }
                }
            }

            ModelState.AddModelError("", "Sign In Failed");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var model = new AccountViewModel();

                
                return View(model);
            }

            return RedirectToAction("Logout", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var isSuperAdmin = await _userManager.IsInRoleAsync(user, RoleType.SuperAdministrator.ToString());
                if (!isSuperAdmin)
                {
                    await _signInManager.SignOutAsync();
                    await _userManager.DeleteAsync(user);
                }
                else
                {
                    return new StatusCodeResult((int)HttpStatusCode.Forbidden);
                }
            }

            return RedirectToAction("Login", "Account");
        }
    }
}