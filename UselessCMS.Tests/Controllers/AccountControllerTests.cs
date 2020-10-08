using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;
using UselessCMS.Controllers;
using UselessCMS.Models.Accounts;
using UselessCore.Enums;
using UselessCore.Model.Users;
using UselessTestingCore.Mocks.Identity;
using Xunit;

namespace UselessCMS.Tests.Controllers
{
    public class AccountControllerTests
    {
        IMapper mapper;
        AccountController controller;
        Mock<IUrlHelper> mockUrlHelper;
        FakeUserManager userManager;
        Mock<SignInManager<User>> mockSignInManager;

        public AccountControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCMS",
                })
            );
            mapper = new Mapper(configuration);
            userManager = new FakeUserManager();

            mockSignInManager = new Mock<SignInManager<User>>(
                userManager,
                new Mock<IHttpContextAccessor>().Object, 
                new Mock<IUserClaimsPrincipalFactory<User>>().Object, 
                null, null, null,null);

            mockUrlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);
            controller = new AccountController(mockSignInManager.Object, userManager, new FakeRoleManager(),mapper)
            {
                Url = mockUrlHelper.Object
            };
        }

        [Fact]
        public void Login_RedirectsToHome_WhenUserIsSignedIn()
        {
            // Arrange
            mockSignInManager.Setup(x => x.IsSignedIn(It.IsAny<ClaimsPrincipal>())).Returns(true);

            // Act
            var result = controller.Login();

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task LoginPost_RedirectsToHome_WhenUserIsAdmin()
        {
            // Arrange
            var model = new LoginViewModel
            {
                Username = "John",
                Password = "abcd1234",
            };

            mockUrlHelper.Setup(x => x.IsLocalUrl(It.IsAny<string>())).Returns(true);
            mockSignInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = await controller.Login(model);

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task LoginPost_RedirectsToReturnUrl_WhenReturnUrlInModelIsValid()
        {
            // Arrange
            var model = new LoginViewModel
            {
                Username = "John",
                Password = "abcd1234",
                ReturnUrl = "/game"
            };

            mockUrlHelper.Setup(x => x.IsLocalUrl(It.IsAny<string>())).Returns(true);
            mockSignInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = await controller.Login(model);

            // Arrange
            var redirect = Assert.IsType<RedirectResult>(result);
            Assert.Equal(model.ReturnUrl, redirect.Url);
        }

        [Fact]
        public async Task LoginPost_RedirectsToHome_WhenReturnUrlInModelIsNotLocal()
        {
            // Arrange
            var model = new LoginViewModel
            {
                Username = "John",
                Password = "abcd1234",
                ReturnUrl = "www.google.com"
            };

            mockUrlHelper.Setup(x => x.IsLocalUrl(It.IsAny<string>())).Returns(false);
            mockSignInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = await controller.Login(model);

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task LoginPost_ReturnsModel_WhenUserIsNotAdmin()
        {
            // Arrange
            var model = new LoginViewModel
            {
                Username = "test",
                Password = "abcd1234",
            };
            userManager.CurrentRole = RoleType.Standard;

            mockUrlHelper.Setup(x => x.IsLocalUrl(It.IsAny<string>())).Returns(true);

            // Act
            var result = await controller.Login(model);

            // Arrange
            Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async Task LoginPost_ReturnsModel_WhenInvalid()
        {
            // Arrange
            var model = new LoginViewModel
            {
                Username = "test",
                Password = null,
            };

            mockUrlHelper.Setup(x => x.IsLocalUrl(It.IsAny<string>())).Returns(true);
            controller.ModelState.AddModelError("Password", "Required");

            // Act
            var result = await controller.Login(model);

            // Arrange
            Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async Task RegisterPost_ReturnsModel_WhenInvalid()
        {
            // Arrange
            var model = new RegisterViewModel
            {
                Username = "test",
                Password = null,
                ConfirmPassword = null
            };

            controller.ModelState.AddModelError("Password", "Required");

            // Act
            var result = await controller.Register(model);

            // Arrange
            Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
        }

        [Fact]
        public async Task RegisterPost_RedirectToLogin_WhenValid()
        {
            // Arrange
            var model = new RegisterViewModel
            {
                Username = "test",
                Password = "abcd1234",
                ConfirmPassword = "abcd1234"
            };

            // Act
            var result = await controller.Register(model);

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Account", redirectToActionResult.ControllerName);
            Assert.Equal("Login", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Register_RedirectsToHome_WhenUserIsSignedIn()
        {
            // Arrange
            mockSignInManager.Setup(x => x.IsSignedIn(It.IsAny<ClaimsPrincipal>())).Returns(true);

            // Act
            var result = controller.Register();

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteAsync_RedirectsToLogin_WhenUserDoesntExistAsync()
        {
            // Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = await controller.DeleteAsync();

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Account", redirectToActionResult.ControllerName);
            Assert.Equal("Login", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsForbidden_WhenUserIsSuperAdmin()
        {
            // Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            userManager.CurrentRole = RoleType.SuperAdministrator;

            // Act
            var result = await controller.DeleteAsync();

            // Arrange
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(403, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task DeleteAsync_Success_WhenUserIsNotSuperAdmin()
        {
            // Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            userManager.CurrentRole = RoleType.Administrator;

            // Act
            var result = await controller.DeleteAsync();

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Account", redirectToActionResult.ControllerName);
            Assert.Equal("Login", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Manage_RedirectsToLogout_WhenUserDoesntExistAsync()
        {
            // Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            userManager.CurrentUser = null;

            // Act
            var result = await controller.Manage();

            // Arrange
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Account", redirectToActionResult.ControllerName);
            Assert.Equal("Logout", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Logout_Redirects()
        {
            //Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var result = controller.Logout();

            //Assert
            Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public void AccessDenied_RedirectsToAction()
        {
            //Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var result = controller.AccessDenied();

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
