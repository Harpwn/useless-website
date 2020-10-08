using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UselessCMS.Controllers;
using Xunit;
using Microsoft.AspNetCore.Authorization;
using UselessCMS.Models.Home;
using UselessCore.Enums;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using UselessTestingCore.Mocks.Identity;

namespace UselessCMS.Tests.Controllers
{
    public class HomeControllerTests
    {
        HomeController controller;
        FakeUserManager userManager;
        IMapper mapper;

        public HomeControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCMS",
                })
            );
            mapper = new Mapper(configuration);
            userManager = new FakeUserManager();

            controller = new HomeController(userManager, mapper);
        }

        [Fact]
        public void Controller_IsDecoratedWithAuthorizeAttribute()
        {
            //Arrange
            var attributes = controller.GetType().GetCustomAttributes(typeof(AuthorizeAttribute), true);

            //Assert
            Assert.True(attributes.Any(), "No AuthorizeAttribute found on Index");
        }

        [Fact]
        public async Task Index_ReturnsModelWithAdminRole_WhenUserIsNotSuperAdmin()
        {
            //Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<HomePageViewModel>(viewResult.ViewData.Model);
            Assert.Equal(RoleType.Administrator, model.Role);
        }

        [Fact]
        public async Task Index_ReturnsModelWithSuperAdminRole_WhenUserIsSuperAdmin()
        {
            //Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            userManager.CurrentRole = RoleType.SuperAdministrator;

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<HomePageViewModel>(viewResult.ViewData.Model);
            Assert.Equal(RoleType.SuperAdministrator, model.Role);
        }
    }
}
