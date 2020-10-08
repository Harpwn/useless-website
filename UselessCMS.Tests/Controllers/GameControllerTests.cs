using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UselessCMS.Controllers;
using UselessCMS.Models.Games;
using UselessCore.Model.Games;
using UselessCore.Services.Games;
using UselessCore.Services.Games.Dtos;
using Xunit;

namespace UselessCMS.Tests.Controllers
{
    public class GameControllerTests
    {
        GameController controller;
        Mock<IGameService> mockGameService;
        IMapper mapper;

        public GameControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCMS",
                })
            );
            mapper = new Mapper(configuration);
            mockGameService = new Mock<IGameService>();

            controller = new GameController(mockGameService.Object, mapper);
        }

        [Fact]
        public async Task Edit_Returns404_WhenGameDoesntExist()
        {
            //Arrange
            var game = new Game
            {
                Name = "test"
            };
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((GameDto)null);

            //Act
            var result = await controller.Edit(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task EditPost_ReturnsModel_WhenModelInvalid()
        {
            //Arrange
            var model = new GameEditViewModel
            {
                Name = "test"
            };
            controller.ModelState.AddModelError("", "error");

            //Act
            var result = await controller.Edit(model);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<GameEditViewModel>(viewResult.Model);
        }

        [Fact]
        public async Task EditPost_Returns404_WhenGameDoesntExist()
        {
            //Arrange
            var model = new GameEditViewModel
            {
                Id = 1,
                Name = "test"
            };
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((GameDto)null);

            //Act
            var result = await controller.Edit(model);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GameLogo_Returns404_WhenGameNotExists()
        {
            //Arrange
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((GameDto)null);

            //Act
            var result = await controller.GameLogo(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GameLogo_Returns404_WhenGameLogoNotExists()
        {
            //Arrange
            var game = new GameDto
            {
                Name = "test"
            };
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(game);

            //Act
            var result = await controller.GameLogo(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Delete_Return404_WhenGameNotExists()
        {
            //Arrange
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((GameDto)null);

            //Act
            var result = await controller.Delete(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
    }
}
