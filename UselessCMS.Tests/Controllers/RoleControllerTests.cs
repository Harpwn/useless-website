using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UselessCMS.Controllers;
using UselessCMS.Models.Roles;
using UselessCore.Enums;
using Xunit;
using System.Threading.Tasks;
using AutoMapper;
using UselessTestingCore.Mocks.Identity;

namespace UselessCMS.Tests.Controllers
{
    public class RoleControllerTests
    {
        RoleController controller;
        FakeUserManager userManager;
        IMapper mapper;

        public RoleControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCMS",
                })
            );
            mapper = new Mapper(configuration);

            userManager = new FakeUserManager();
            controller = new RoleController(userManager,mapper);
        }


        [Fact]
        public async Task Index_DoesntReturnStandardRoleAsync()
        {
            //Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<RolesPageViewModel>(viewResult.ViewData.Model);
            Assert.False(model.UserRoles.ContainsKey(RoleType.Standard));
        }

        [Fact]
        public async Task AddRoleToUser_ReturnsModel_WhenUserDoesntExist()
        {
            //Arrange
            userManager.CurrentRole = RoleType.Standard;
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var result = await controller.AddRoleToUser("username",RoleType.Administrator.ToString());

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Role", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task RemoveRoleFromUser_ReturnsModel_WhenUserDoesntExist()
        {
            //Arrange
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            userManager.CurrentRole = RoleType.Standard;

            //Act
            var result = await controller.RemoveRoleFromUser("-1", RoleType.Administrator.ToString());

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Role", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
