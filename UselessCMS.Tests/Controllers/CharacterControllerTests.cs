using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UselessCMS.Controllers;
using UselessCMS.Models.Characters;
using UselessCore.Model.Characters;
using UselessCore.Model.Games;
using UselessCore.Services.Characters;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries;
using UselessCore.Services.Games;
using UselessCore.Services.Games.Dtos;
using Xunit;

namespace UselessCMS.Tests.Controllers
{
    public class CharacterControllerTests
    {
        CharacterController controller;
        IMapper mapper;
        Mock<IGameService> mockGameService;
        Mock<ICharacterService> mockCharacterService;
        Mock<IEntryService> mockEntryService;

        public CharacterControllerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCMS",
                })
            );
            mapper = new Mapper(configuration);

            mockGameService = new Mock<IGameService>();
            mockCharacterService = new Mock<ICharacterService>();
            mockEntryService = new Mock<IEntryService>();

            controller = new CharacterController(mockCharacterService.Object, mockGameService.Object, mockEntryService.Object, mapper);
        }

        [Fact]
        public async Task ListByGame_Returns404_WhenGameDoesntExist()
        {
            //Arrange
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((GameDto)null);


            //Act
            var result = await controller.ListByGame(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Edit_Returns404_WhenCharacterDoesntExist()
        {
            //Arrange
            mockCharacterService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((CharacterDto)null);

            //Act
            var result = await controller.Edit(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task EditPost_ReturnsView_WhenInvalidModel()
        {
            //Arrange
            var model = new CharacterEditViewModel()
            {
                Name = "Test"
            };
            mockCharacterService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((CharacterDto)null);
            controller.ModelState.AddModelError("Test", "");
            
            //Act
            var result = await controller.Edit(model);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public async Task EditPost_Returns404_WhenGameDoesntExist()
        {
            //Arrange
            var model = new CharacterEditViewModel
            {
                Name = "Test"
            };
            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((GameDto)null);

            //Act
            var result = await controller.Edit(model);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task EditPost_Returns404_WhenCharacterDoesntExist()
        {
            //Arrange
            var model = new CharacterEditViewModel
            {
                Id = 0,
                Name = "Test"
            };

            var game = new GameDto()
            {
                Name = "test"
            };

            mockGameService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(game);
            mockCharacterService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((CharacterDto)null);

            //Act
            var result = await controller.Edit(model);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task IconImage_Returns404_WhenCharacterNotExists()
        {
            //Arrange
            mockCharacterService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((CharacterDto)null);

            //Act
            var result = await controller.IconImage(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task ImageIcon_Returns404_WhenGameLogoNotExists()
        {
            //Arrange
            var character = new CharacterDto
            {
                Name = "Test"
            };
            mockCharacterService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(character);

            //Act
            var result = await controller.IconImage(0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Delete_Returns404_WhenCharacterNotExists()
        {
            //Arrange
            mockCharacterService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((CharacterDto)null);

            //Act
            var result = await controller.Delete(0,0);

            //Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
    }
}
