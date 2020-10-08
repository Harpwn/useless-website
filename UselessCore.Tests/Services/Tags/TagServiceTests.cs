using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Enums.Tag;
using UselessCore.Model.Characters;
using UselessCore.Model.Entries;
using UselessCore.Model.Games;
using UselessCore.Model.Images;
using UselessCore.Model.Tags;
using UselessCore.Model.Users;
using UselessCore.Services.Tags;
using UselessCore.Services.Tags.Dtos;
using UselessCore.Tests.Fixtures;
using Xunit;

namespace UselessCore.Tests.Services.Tags
{
    public class TagServiceTests : IClassFixture<DatabaseFixture>
    {
        TagService service;
        DatabaseFixture fixture;
        IMapper mapper;

        public TagServiceTests(DatabaseFixture fixture)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            mapper = new Mapper(configuration);

            var mockMemoryCache = new Mock<IMemoryCache>();
            this.fixture = fixture;
            service = new TagService(fixture.Context, mockMemoryCache.Object, mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllTags()
        {
            //ARRANGE
            fixture.Context.Add(new Tag { Name = "test1", Type = TagType.System });
            fixture.Context.Add(new Tag { Name = "test2", Type = TagType.System });
            fixture.Context.Add(new Tag { Name = "test3", Type = TagType.System });
            fixture.Context.SaveChanges();
            var count = await fixture.Context.Tags.CountAsync();

            //ACT
            var resultsCount = (await service.GetAllAsync()).Count();

            //ASSERT
            Assert.Equal(count, resultsCount);
        }

        [Fact]
        public async Task GetOrCreateTagAsync_DoesntCreateNewTag_WhenTagExists()
        {
            //ARRANGE
            var tagName = Guid.NewGuid().ToString().ToUpper();
            fixture.Context.Add(new Tag { Name = tagName, Type = TagType.System });
            fixture.Context.SaveChanges();
            var count = await fixture.Context.Tags.CountAsync();

            //ACT
            var result = await service.GetOrCreateTagAsync(tagName);

            //ASSERT
            Assert.NotNull(result);
            Assert.Equal(result.Name, tagName);
            Assert.Equal(count, await fixture.Context.Tags.CountAsync());
        }

        [Fact]
        public async Task GetOrCreateTagAsync_CreatesNewTag_WhenTagDoesntExists()
        {
            //ARRANGE
            var tagName = Guid.NewGuid().ToString().ToUpper();
            var count = await fixture.Context.Tags.CountAsync();

            //ACT
            var result = await service.GetOrCreateTagAsync(tagName);

            //ASSERT
            Assert.NotNull(result);
            Assert.Equal(result.Name, tagName);
            Assert.Equal(count+1, await fixture.Context.Tags.CountAsync());
        }

        [Fact]
        public async Task CreateIfNotExistsAsync_CreatesNewTag_WhenTagDoesntExists()
        {
            //ARRANGE
            var tagName = Guid.NewGuid().ToString().ToUpper();
            var count = await fixture.Context.Tags.CountAsync();
            var tagDto = new TagDto
            {
                Name = tagName,
                Type = TagType.UserGenerated
            };

            //ACT
            var result = await service.TryCreateAsync(tagDto);

            //ASSERT
            Assert.Equal(count + 1, await fixture.Context.Tags.CountAsync());
        }

        [Fact]
        public async Task CreateIfNotExistsAsync_DoesntCreateNewTag_WhenTagExists()
        {
            //ARRANGE
            var tagName = Guid.NewGuid().ToString().ToUpper();
            fixture.Context.Add(new Tag { Name = tagName, Type = TagType.System });
            fixture.Context.SaveChanges();
            var count = await fixture.Context.Tags.CountAsync();
            var tagDto = new TagDto
            {
                Name = tagName,
                Type = TagType.UserGenerated
            };

            //ACT
            var result = await service.TryCreateAsync(tagDto);

            //ASSERT
            Assert.Equal(count, await fixture.Context.Tags.CountAsync());
        }

        [Fact]
        public async Task TryDeleteAsync_ReturnsFalse_WhenTagDoesntExist()
        {
            //ARRANGE
            var tagId = 100;
            var currentCount = await fixture.Context.Tags.CountAsync();

            //ACT
            var result = await service.TryDeleteAsync(tagId);

            //ASSERT
            Assert.Equal(currentCount, await fixture.Context.Tags.CountAsync());
            Assert.False(result);
        }

        [Fact]
        public async Task TryDeleteAsync_DeletesTag_WhenTagExists()
        {
            //ARRANGE
            var tag = new Tag
            {
                Name = "test",
                Type = TagType.System
            };
            fixture.Context.Tags.Add(tag);
            fixture.Context.SaveChanges();
            var tagsCount = await fixture.Context.Tags.CountAsync();

            //ACT
            var result = await service.TryDeleteAsync(tag.Id);

            //ASSERT
            Assert.True(result);
            Assert.Equal(tagsCount - 1, await fixture.Context.Tags.CountAsync());
        }

        [Fact]
        public async Task TryDeleteAsync_ReturnsFalse_WhenTagHasEntries()
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

            character.IconImage = new Image
            {
                File = new byte[0]
            };

            character.TagEntries.Add(new CharacterTagEntry { User = user, Type = CharacterTagEntryType.Main, Character = character, LinkedTag = tag });

            fixture.Context.Characters.Add(character);
            fixture.Context.SaveChanges();

            var tags = await fixture.Context.Tags.CountAsync();
            var tagEntries = await fixture.Context.TagEntries.CountAsync();

            //ACT
            var result = await service.TryDeleteAsync(tag.Id);

            //ASSERT
            Assert.False(result);
            Assert.Equal(tagEntries, await fixture.Context.TagEntries.CountAsync());
            Assert.Equal(tags, await fixture.Context.Tags.CountAsync());
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsTag()
        {
            //ARRANGE
            var tag = new Tag { Name = "test1", Type = TagType.System };
            fixture.Context.Tags.Add(tag);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetByIDAsync(tag.Id);

            //ASSERT
            Assert.Equal(result.Id, tag.Id);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsNull_WhenTagDoesntExist()
        {
            //ARRANGE
            var tagID = 999;

            //ACT
            var result = await service.GetByIDAsync(tagID);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public async Task SearchAsync_ReturnsMatchingTags_WhenTagsExists()
        {
            fixture.Context.Tags.Add(new Tag { Name = "search_test", Type = TagType.System });
            fixture.Context.Tags.Add(new Tag { Name = "search_test1", Type = TagType.System });
            fixture.Context.Tags.Add(new Tag { Name = "search_test2", Type = TagType.System });
            fixture.Context.SaveChanges();

            //ACT
            var result = (await service.SearchAsync("search_test")).Count();

            //ASSERT
            Assert.True(result >= 3);
        }
    }
}
