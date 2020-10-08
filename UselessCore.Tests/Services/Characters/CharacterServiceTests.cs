using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Enums.Tag;
using UselessCore.Model;
using UselessCore.Model.Characters;
using UselessCore.Model.Entries;
using UselessCore.Model.Games;
using UselessCore.Model.Images;
using UselessCore.Model.Tags;
using UselessCore.Model.Users;
using UselessCore.Services.Characters;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries;
using UselessCore.Services.Games;
using UselessCore.Services.Images.Dtos;
using UselessCore.Tests.Fixtures;
using UselessCore.Tests.Stubs.Entries;
using Xunit;

namespace UselessCore.Tests.Services.Characters
{
    public class CharacterServiceTests : IClassFixture<DatabaseFixture>
    {
        CharacterService service;
        DatabaseFixture fixture;
        IMapper mapper;
        Mock<ISectionBuilderFactory> mockSectionBuilderFactory;

        public CharacterServiceTests(DatabaseFixture fixture)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            mapper = new Mapper(configuration);

            var mockMemoryCache = new Mock<IMemoryCache>();
            this.fixture = fixture;
            mockSectionBuilderFactory = new Mock<ISectionBuilderFactory>();
            mockSectionBuilderFactory.Setup(msbf => msbf.GetSectionBuilder(It.IsAny<Character>(), It.IsAny<List<BaseCharacterDto>>(), It.IsAny<string>())).Returns(new SectionBuilderStub());

            service = new CharacterService(fixture.Context, mockMemoryCache.Object, mapper, mockSectionBuilderFactory.Object);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsFalse_WhenCharacterDoesntExist()
        {
            //ARRANGE
            var characterId = 100;
            var currentCount = await fixture.Context.Characters.CountAsync();

            //ACT
            var result = await service.DeleteAsync(characterId);

            //ASSERT
            Assert.Equal(currentCount, await fixture.Context.Characters.CountAsync());
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteAsync_DeletesCharacterAndRelatedEntities_WhenCharacterDeleted()
        {
            //ARRANGE
            var user = new User
            {
                Email = "test@test.com",
                UserName = "testuser"
            };

            var game = new Game
            {
                Name = "Test",
                Status = EntityStatus.Active
            };

            var tag = new Tag
            {
                Name = "test",
                Type = TagType.System
            };

            var character = new Character
            {
                Name = "Test",
                Game = game
            };

            var character2 = new Character
            {
                Name = "Test1",
                Game = game
            };

            character.IconImage = new Image
            {
                File = new byte[0]
            };

            character.LinkEntries.Add(new CharacterLinkEntry { User = user, Type = CharacterLinkEntryType.CounteredBy, Character = character, LinkedCharacter = character });
            character.StringEntries.Add(new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Character = character, Text = "test" });
            character.ValueEntries.Add(new CharacterValueEntry { User = user, Type = CharacterValueEntryType.Tier, Character = character, Value = 0 });
            character.TagEntries.Add(new CharacterTagEntry { User = user, Type = CharacterTagEntryType.Main, Character = character, LinkedTag = tag });

            fixture.Context.Characters.AddRange(new Character[] { character2, character });
            fixture.Context.SaveChanges();

            var characterCount = await fixture.Context.Characters.CountAsync();
            var imageCount = await fixture.Context.Images.CountAsync();
            var linkEntries = await fixture.Context.LinkEntries.CountAsync();
            var stringEntries = await fixture.Context.StringEntries.CountAsync();
            var valueEntries = await fixture.Context.ValueEntries.CountAsync();
            var tagEntries = await fixture.Context.TagEntries.CountAsync();
            var gameCount = await fixture.Context.Games.CountAsync();

            //ACT
            var result = await service.DeleteAsync(character.Id);

            //ASSERT
            Assert.True(result);
            Assert.Equal(characterCount - 1, await fixture.Context.Characters.CountAsync());
            Assert.Equal(imageCount - 1, await fixture.Context.Images.CountAsync());
            Assert.Equal(linkEntries - 1, await fixture.Context.LinkEntries.CountAsync());
            Assert.Equal(stringEntries - 1, await fixture.Context.StringEntries.CountAsync());
            Assert.Equal(valueEntries - 1, await fixture.Context.ValueEntries.CountAsync());
            Assert.Equal(tagEntries - 1, await fixture.Context.TagEntries.CountAsync());
            Assert.Equal(gameCount, await fixture.Context.Games.CountAsync());
        }

        [Fact]
        public async Task AddAsync_AddsCharacter_WhenCharacterAdded()
        {
            //ARRANGE
            var game = new Game { Name = "Test" };
            var specificCharacterName = Guid.NewGuid().ToString();
            fixture.Context.Add(game);
            fixture.Context.SaveChanges();
            var currentCount = await fixture.Context.Characters.CountAsync();
            var imageCount = await fixture.Context.Images.CountAsync();
            var character = new CharacterDto
            {
                Name = specificCharacterName,
                GameId = game.Id,
                IconImage = new ImageDto
                {
                    File = new byte[0]
                }
            };

            //ACT
            var result = await service.AddAsync(character);

            //ASSERT
            var existingCharacter = await fixture.Context.Characters.SingleOrDefaultAsync(g => g.Name == specificCharacterName);
            Assert.NotNull(existingCharacter);
            Assert.NotNull(existingCharacter.IconImage);
            Assert.Equal(existingCharacter.Id, result);
            Assert.Equal(currentCount + 1, await fixture.Context.Characters.CountAsync());
            Assert.Equal(imageCount + 1, await fixture.Context.Images.CountAsync());
        }

        [Fact]
        public async Task AddAsync_AddsCharacter_WhenCharacterAddedWithoutIcon()
        {
            //ARRANGE
            var game = new Game { Name = "Test" };
            var specificCharacterName = Guid.NewGuid().ToString();
            fixture.Context.Add(game);
            fixture.Context.SaveChanges();
            var currentCount = await fixture.Context.Characters.CountAsync();
            var character = new CharacterDto
            {
                Name = specificCharacterName,
                GameId = game.Id
            };

            //ACT
            var result = await service.AddAsync(character);

            //ASSERT
            var existingCharacter = await fixture.Context.Characters.SingleOrDefaultAsync(g => g.Name == specificCharacterName);
            Assert.NotNull(existingCharacter);
            Assert.Equal(existingCharacter.Id, result);
            Assert.Equal(currentCount + 1, await fixture.Context.Characters.CountAsync());
        }

        [Fact]
        public async Task GetAllForGameAsync_ReturnsNull_WhenGameDoesntExist()
        {
            //ARRANGE
            var gameId = 999;

            //ACT
            var result = await service.GetAllForGameAsync(gameId);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllForGameAsync_ReturnsOnlyWithStatus_WhenStatusSet()
        {
            //ARRANGE
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            fixture.Context.Characters.Add(new Character { Name = "Test1", Status = EntityStatus.Active, Game = game });
            fixture.Context.Characters.Add(new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game });
            fixture.Context.SaveChanges();

            //ACT
            var getResult = await service.GetAllForGameAsync(game.Id, EntityStatus.Active);

            //ASSERT
            Assert.Single(getResult);
        }

        [Fact]
        public async Task GetAllForGameAsync_ReturnsAllCharactersForGame()
        {
            //ARRANGE
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            game.Characters.Add(new Character { Name = "Test1", Status = EntityStatus.Active, Game = game });
            game.Characters.Add(new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game });
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();

            //ACT
            var results = await service.GetAllForGameAsync(game.Id);

            //ASSERT
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOnlyWithStatus_WhenStatusSet()
        {
            //ARRANGE
            var count = await fixture.Context.Characters.CountAsync(c => c.Status == EntityStatus.Active);
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            game.Characters.Add(new Character { Name = "Test1", Status = EntityStatus.Active, Game = game });
            game.Characters.Add(new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game });
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();

            //ACT
            var results = await service.GetAllAsync(EntityStatus.Active);

            //ASSERT
            Assert.Equal(count + 1, results.Count());

        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCharacters()
        {
            //ARRANGE
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            game.Characters.Add(new Character { Name = "Test1", Status = EntityStatus.Active, Game = game });
            game.Characters.Add(new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game });
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.Characters.CountAsync();

            //ACT
            var resultsCount = (await service.GetAllAsync()).Count();

            //ASSERT
            Assert.Equal(count, resultsCount);
        }

        [Fact]
        public async Task EditAsync_ReturnsFalse_WhenCharacterDoesntExist()
        {
            //ARRANGE
            var characterDto = new CharacterDto
            {
                Id = 999,
                Name = "doesnt exist"
            };

            //ACT
            var result = await service.EditAsync(characterDto);

            //ASSERT
            Assert.False(result);
        }

        [Fact]
        public async Task EditAsync_EditsCharacter_WhenCharacterExists()
        {
            //ARRANGE
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            var character = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            game.Characters.Add(character);
            fixture.Context.Games.Add(game);
            fixture.Context.SaveChanges();
            var characterDto = mapper.Map<CharacterDto>(character);

            //ACT
            var result = await service.EditAsync(characterDto);

            //ASSERT
            Assert.True(result);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsChampion_WhenChampionExists()
        {
            //ARRANGE
            var newCharacter = new Character { Name = "Test", Game = new Game { Name = "Test", Status = EntityStatus.Active } };
            fixture.Context.Characters.Add(newCharacter);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetByIdAsync(newCharacter.Id);

            //ASSERT
            Assert.Equal(newCharacter.Id, result.Id);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsNull_WhenCharacterDoesntExist()
        {
            //ARRANGE
            var characterID = 999;

            //ACT
            var result = await service.GetByIdAsync(characterID);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public async Task GetSectionsAsync_ReturnsNull_WhenCharacterDoesntExist()
        {
            //ARRANGE
            var characterID = 999;

            //ACT
            var result = await service.GetSectionsAsync(characterID);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public async Task GetSectionsAsync_ReturnsSections_WhenCharacterExists()
        {
            //ARRANGE
            var newCharacter = new Character { Name = "Test", Game = new Game { Name = "Test", Status = EntityStatus.Active } };
            fixture.Context.Characters.Add(newCharacter);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetSectionsAsync(newCharacter.Id);

            //ASSERT
            Assert.IsType<List<ISection>>(result);
        }


    }
}
