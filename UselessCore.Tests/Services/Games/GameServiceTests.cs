using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Model.Characters;
using UselessCore.Model.Games;
using UselessCore.Services.Games;
using UselessCore.Services.Games.Dtos;
using UselessCore.Services.Images.Dtos;
using UselessCore.Tests.Fixtures;
using Xunit;

namespace UselessCore.Tests.Services.Games
{
    public class GameServiceTests : IClassFixture<DatabaseFixture>
    {
        GameService service;
        DatabaseFixture fixture;
        IMapper mapper;

        public GameServiceTests(DatabaseFixture fixture)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            mapper = new Mapper(configuration);

            var mockMemoryCache = new Mock<IMemoryCache>();
            this.fixture = fixture;
            service = new GameService(fixture.Context, mockMemoryCache.Object, mapper);
        }

        [Fact]
        public async Task AddAsync_AddsGame_WhenGameAdded()
        {
            //ARRANGE
            var specificGameName = Guid.NewGuid().ToString();
            var count = await fixture.Context.Games.CountAsync();
            var imageCount = await fixture.Context.Images.CountAsync();
            var gameDto = new GameDto
            {
                Name = specificGameName,
                GameLogo = new ImageDto 
                { 
                    File = new byte[0]
                }
            };

            //ACT
            var result = await service.AddAsync(gameDto);

            //ASSERT
            var game = await fixture.Context.Games.SingleOrDefaultAsync(g => g.Name == specificGameName);
            Assert.Equal(count + 1, await fixture.Context.Games.CountAsync());
            Assert.Equal(imageCount + 1, await fixture.Context.Images.CountAsync());
            Assert.NotNull(game);
            Assert.NotNull(game.GameLogo);
            Assert.Equal(game.Id,result);
        }

        [Fact]
        public async Task AddAsync_AddsGame_WhenGameAddedWithoutIcon()
        {
            //ARRANGE
            var specificGameName = Guid.NewGuid().ToString();
            var count = await fixture.Context.Games.CountAsync();
            var gameDto = new GameDto
            {
                Name = specificGameName,
            };

            //ACT
            var result = await service.AddAsync(gameDto);

            //ASSERT
            var game = await fixture.Context.Games.SingleOrDefaultAsync(g => g.Name == specificGameName);
            Assert.Equal(count + 1, await fixture.Context.Games.CountAsync());
            Assert.NotNull(game);
            Assert.Equal(game.Id, result);
        }

        [Fact]
        public async Task EditAsync_ReturnsFalse_WhenGameDoesntExist()
        {
            //ARRANGE
            var gameDto = new GameDto
            {
                Id = 999,
                Name = "test2"
            };

            //ACT
            var result = await service.EditAsync(gameDto);

            //ASSERT
            Assert.False(result);
        }

        [Fact]
        public async Task EditAsync_EditsGame_WhenGameExists()
        {
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();
            var dto = mapper.Map<GameDto>(game);

            //ACT
            var result = await service.EditAsync(dto);

            //ASSERT
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalse_WhenGameDoesntExist()
        {
            //ARRANGE
            var gameId = 999;

            //ACT
            var result = await service.DeleteAsync(gameId);

            //ASSERT
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteAsync_DeletesGameAndRelatedEntities_WhenGameDeleted()
        {
            var game = new Game { Name = "test1", Status = EntityStatus.Archived, GameLogo = new Model.Images.Image { File = new byte[1] } };
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.Games.CountAsync();
            var imageCount = await fixture.Context.Images.CountAsync();

            //ACT
            var result = await service.DeleteAsync(game.Id);

            //ASSERT
            Assert.True(result);
            Assert.Equal(count - 1, await fixture.Context.Games.CountAsync());
            Assert.Equal(imageCount - 1, await fixture.Context.Images.CountAsync());
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalse_WhenGameHasCharacters()
        {
            var game = new Game { Name = "test1", Status = EntityStatus.Archived };
            game.Characters.Add(new Character { Name = "test1" });
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.DeleteAsync(game.Id);

            //ASSERT
            Assert.False(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllGames()
        {
            //ARRANGE
            fixture.Context.Add(new Game { Name = "test", Status = EntityStatus.Active });
            fixture.Context.Add(new Game { Name = "test2", Status = EntityStatus.Archived });
            fixture.Context.Add(new Game { Name = "Test3", Status = EntityStatus.Draft });
            fixture.Context.SaveChanges();
            var count = await fixture.Context.Games.CountAsync();

            //ACT
            var resultsCount = (await service.GetAllAsync()).Count();

            //ASSERT
            Assert.Equal(count, resultsCount);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsWithStatus_WhenStatusSet()
        {
            //ARRANGE
            var activeCount = await fixture.Context.Games.CountAsync(g => g.Status == EntityStatus.Active);
            fixture.Context.Games.Add(new Game { Name = "test1", Status = EntityStatus.Archived });
            fixture.Context.SaveChanges();

            //ACT
            var resultCount = (await service.GetAllAsync(EntityStatus.Active)).Count();

            //ASSERT
            Assert.Equal(activeCount, resultCount);

        }

        [Fact]
        public async Task GetByIDAsync_ReturnsGame()
        {
            //ARRANGE
            var game = new Game { Name = "test1", Status = EntityStatus.Archived };
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetByIdAsync(game.Id);

            //ASSERT
            Assert.Equal(result.Id, game.Id);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsNull_WhenGameDoesntExist()
        {
            //ARRANGE
            var gameID = 999;

            //ACT
            var result = await service.GetByIdAsync(gameID);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public async Task GetLogoAsync_ReturnsLogo()
        {
            //ARRANGE
            var game = new Game { Name = "test1", Status = EntityStatus.Archived, GameLogo = new Model.Images.Image { File = new byte[1] } };
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetLogoAsync(game.Id);

            //ASSERT
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetLogoAsync_ReturnsNull_WhenNoLogo()
        {
            //ARRANGE
            var game = new Game { Name = "test1", Status = EntityStatus.Archived };
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetLogoAsync(game.Id);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public async Task GetLogoAsync_ReturnsNull_WhenGameDoesntExist()
        {
            //ARRANGE
            var gameId = 999;

            //ACT
            var result = await service.GetLogoAsync(gameId);

            //ASSERT
            Assert.Null(result);
        }

    }
}
