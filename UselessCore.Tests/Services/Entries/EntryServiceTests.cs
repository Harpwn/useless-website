using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Enums.Tag;
using UselessCore.Model.Characters;
using UselessCore.Model.Entries;
using UselessCore.Model.Games;
using UselessCore.Model.Tags;
using UselessCore.Model.Users;
using UselessCore.Services.Entries;
using UselessCore.Services.Tags;
using UselessCore.Tests.Fixtures;
using Xunit;

namespace UselessCore.Tests.Services.Entries
{
    public class EntryServiceTests : IClassFixture<DatabaseFixture>
    {
        EntryService service;
        DatabaseFixture fixture;
        Mock<ITagService> mockTagService;
        IMapper mapper;

        public EntryServiceTests(DatabaseFixture fixture)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            mapper = new Mapper(configuration);

            var mockMemoryCache = new Mock<IMemoryCache>();
            mockTagService = new Mock<ITagService>();
            this.fixture = fixture;

            service = new EntryService(fixture.Context, mockMemoryCache.Object, mockTagService.Object, mapper);
        }

        [Fact]
        public async Task AddReplaceCharacterLinkEntryAsync_DoestAddLink_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, 999);
            var result2 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, 999, character2.Id);
            var result3 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, Guid.NewGuid().ToString(), character1.Id, character2.Id);

            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.Equal(count, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterLinkEntryAsync_DoesntAddLink_WhenLinkingCharactersFromDifferentGames_AndTypeIsntSimilarInGenre()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var game2 = new Game { Name = "Test2", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game2 };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, character2.Id);

            //ASSERT
            Assert.False(result1);
            Assert.Equal(count, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterLinkEntryAsync_AddsLink_WhenLinkingCharactersFromDifferentGames_AndTypeIsSimilarInGenre()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var game2 = new Game { Name = "Test2", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game2 };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.SimilarInGenre, user.Id, character1.Id, character2.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count + 1, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterLinkEntryAsync_AddsLink_WhenLinkingCharacters()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, character2.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count + 1, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterLinkEntryAsync_DoesntCreateDuplicateLinks_WhenLinkingCharacters()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, character2.Id);
            var result2 = await service.AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, character2.Id);

            //ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.Equal(count + 1, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterTagEntryAsync_DoesntAddTag_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var tagName = "testtag";
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var tag = new Tag { Name = tagName, Type = TagType.UserGenerated };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.Tags.Add(tag);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.TagEntries.CountAsync();

            mockTagService.Setup(mts => mts.GetOrCreateTagAsync(tagName)).ReturnsAsync(tag);

            //ACT
            var result1 = await service.AddReplaceCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, 999, tagName);
            var result2 = await service.AddReplaceCharacterTagEntryAsync(CharacterTagEntryType.Main, Guid.NewGuid().ToString(), character1.Id, tagName);


            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.Equal(count, await fixture.Context.TagEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterTagEntryAsync_AddsTag_WhenAddingTag()
        {
            //ARRANGE
            var tagName = "testtag";
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var tag = new Tag { Name = tagName, Type = TagType.UserGenerated };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.Tags.Add(tag);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.TagEntries.CountAsync();

            mockTagService.Setup(mts => mts.GetOrCreateTagAsync(tagName)).ReturnsAsync(tag);

            //ACT
            var result1 = await service.AddReplaceCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, character1.Id, tagName);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count + 1, await fixture.Context.TagEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterTagEntryAsync_DoesntDuplicateTag_WhenAddingTags()
        {
            //ARRANGE
            var tagName = "testtag";
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var tag = new Tag { Name = tagName, Type = TagType.UserGenerated };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.Tags.Add(tag);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.TagEntries.CountAsync();

            mockTagService.Setup(mts => mts.GetOrCreateTagAsync(tagName)).ReturnsAsync(tag);

            //ACT
            var result1 = await service.AddReplaceCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, character1.Id, tagName);
            var result2 = await service.AddReplaceCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, character1.Id, tagName);

            //ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.Equal(count + 1, await fixture.Context.TagEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterValueEntryAsync_DoesntAddValue_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.TagEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterValueEntryAsync(CharacterValueEntryType.Tier,user.Id,999,0);
            var result2 = await service.AddReplaceCharacterValueEntryAsync(CharacterValueEntryType.Tier, Guid.NewGuid().ToString(), character1.Id, 0);


            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.Equal(count, await fixture.Context.TagEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterValueEntryAsync_AddsValue_WhenValueAdded()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.ValueEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterValueEntryAsync(CharacterValueEntryType.Tier, user.Id, character1.Id, 0);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count + 1, await fixture.Context.ValueEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterValueEntryAsync_DoesntDuplicateValue_WhenAddingValues()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.ValueEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterValueEntryAsync(CharacterValueEntryType.Tier, user.Id,character1.Id,0);
            var result2 = await service.AddReplaceCharacterValueEntryAsync(CharacterValueEntryType.Tier, user.Id, character1.Id, 1);

            //ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.Equal(count + 1, await fixture.Context.ValueEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterStringEntryAsync_DoesntAddString_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, 999, "");
            var result2 = await service.AddReplaceCharacterStringEntryAsync(CharacterStringEntryType.Tips, Guid.NewGuid().ToString(), character1.Id, "");


            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.Equal(count, await fixture.Context.StringEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterStringEntryAsync_AddsString_WhenStringAdded()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, "");

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count + 1, await fixture.Context.StringEntries.CountAsync());
        }

        [Fact]
        public async Task AddReplaceCharacterStringEntryAsync_DoesntDuplicateString_WhenAddingStrings()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.CountAsync();

            //ACT
            var result1 = await service.AddReplaceCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, "");
            var result2 = await service.AddReplaceCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, "");

            //ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.Equal(count + 1, await fixture.Context.StringEntries.CountAsync());
        }

        [Fact]
        public async Task AddCharacterStringEntryVoteAsync_DoesntAddStringVote_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = "" };
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync();

            //ACT
            var result1 = await service.AddCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, 999);
            var result2 = await service.AddCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, 999, stringEntry.Id);
            var result3 = await service.AddCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, Guid.NewGuid().ToString(), character1.Id, stringEntry.Id);


            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.Equal(count, await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync());
        }

        [Fact]
        public async Task AddCharacterStringEntryVoteAsync_AddsStringVote_WhenStringVoteAdded()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = "" };
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync();

            //ACT
            var result1 = await service.AddCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, stringEntry.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count + 1, await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync());
        }

        [Fact]
        public async Task AddCharacterStringEntryVoteAsync_DoesntDuplicateStringVote_WhenAddingStringVotes()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = "" };
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync();

            //ACT
            var result1 = await service.AddCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, stringEntry.Id);
            var result2 = await service.AddCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, stringEntry.Id);

            //ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.Equal(count + 1, await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterLinkEntryAsync_DoesntRemoveEntry_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Active, Game = game };
            var linkEntry = new CharacterLinkEntry { User = user, Type = CharacterLinkEntryType.CounteredBy, LinkedCharacter = character2 };
            character1.LinkEntries.Add(linkEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, 999);
            var result2 = await service.RemoveCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, 999, character2.Id);
            var result3 = await service.RemoveCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, Guid.NewGuid().ToString(), character1.Id, character2.Id);
            var result4 = await service.RemoveCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character2.Id, character1.Id);

            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.Equal(count, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterLinkEntryAsync_RemovesEntry_WhenEntryRemoved()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Active, Game = game };
            var linkEntry = new CharacterLinkEntry { User = user, Type = CharacterLinkEntryType.CounteredBy, LinkedCharacter = character2 };
            character1.LinkEntries.Add(linkEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.LinkEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterLinkEntryAsync(CharacterLinkEntryType.CounteredBy, user.Id, character1.Id, character2.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count - 1, await fixture.Context.LinkEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterTagEntryAsync_DoesntRemoveEntry_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var tag = new Tag { Name = "test", Type = TagType.System };
            var tagEntry = new CharacterTagEntry { User = user, Type = CharacterTagEntryType.Main, LinkedTag = tag };
            character1.TagEntries.Add(tagEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.TagEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, character1.Id, 999);
            var result2 = await service.RemoveCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, 999, tag.Id);
            var result3 = await service.RemoveCharacterTagEntryAsync(CharacterTagEntryType.Main, Guid.NewGuid().ToString(), character1.Id, tag.Id);

            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.Equal(count, await fixture.Context.TagEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterTagEntryAsync_RemovesEntry_WhenEntryRemoved()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var tag = new Tag { Name = "test", Type = TagType.System };
            var tagEntry = new CharacterTagEntry { User = user, Type = CharacterTagEntryType.Main, LinkedTag = tag };
            character1.TagEntries.Add(tagEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.TagEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterTagEntryAsync(CharacterTagEntryType.Main, user.Id, character1.Id, tag.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count - 1, await fixture.Context.TagEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterValueEntryAsync_DoesntRemoveEntry_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var valueEntry = new CharacterValueEntry { User = user, Type = CharacterValueEntryType.Tier, Value = 0 };
            character1.ValueEntries.Add(valueEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.ValueEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterValueEntryAsync(CharacterValueEntryType.Tier, user.Id, character1.Id, 999);
            var result2 = await service.RemoveCharacterValueEntryAsync(CharacterValueEntryType.Tier, user.Id, 999, valueEntry.Id);
            var result3 = await service.RemoveCharacterValueEntryAsync(CharacterValueEntryType.Tier, Guid.NewGuid().ToString(), character1.Id, valueEntry.Id);

            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.Equal(count, await fixture.Context.ValueEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterValueEntryAsync_RemovesEntry_WhenEntryRemoved()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var valueEntry = new CharacterValueEntry { User = user, Type = CharacterValueEntryType.Tier, Value = 0 };
            character1.ValueEntries.Add(valueEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.ValueEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterValueEntryAsync(CharacterValueEntryType.Tier, user.Id, character1.Id, 0);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count - 1, await fixture.Context.ValueEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterStringEntryAsync_DoesntRemoveEntry_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = ""};
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, 999);
            var result2 = await service.RemoveCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, 999, stringEntry.Id);
            var result3 = await service.RemoveCharacterStringEntryAsync(CharacterStringEntryType.Tips, Guid.NewGuid().ToString(), character1.Id, stringEntry.Id);

            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.Equal(count, await fixture.Context.StringEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterStringEntryAsync_RemovesEntry_WhenEntryRemoved()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = "" };
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterStringEntryAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, stringEntry.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count - 1, await fixture.Context.StringEntries.CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterStringEntryVoteAsync_DoesntRemoveEntryVote_WhenRequiredEntitiesDontExist()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = "" };
            var vote = new EntryVote { User = user };
            stringEntry.Votes.Add(vote);
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, 999);
            var result2 = await service.RemoveCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, 999, stringEntry.Id);
            var result3 = await service.RemoveCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, Guid.NewGuid().ToString(), character1.Id, stringEntry.Id);

            //ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.Equal(count, await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync());
        }

        [Fact]
        public async Task RemoveCharacterStringEntryVoteAsync_RemovesEntryVote_WhenEntryVoteRemoved()
        {
            //ARRANGE
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Active };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var stringEntry = new CharacterStringEntry { User = user, Type = CharacterStringEntryType.Tips, Text = "" };
            var vote = new EntryVote { User = user };
            stringEntry.Votes.Add(vote);
            character1.StringEntries.Add(stringEntry);
            fixture.Context.Characters.Add(character1);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();
            var count = await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync();

            //ACT
            var result1 = await service.RemoveCharacterStringEntryVoteAsync(CharacterStringEntryType.Tips, user.Id, character1.Id, stringEntry.Id);

            //ASSERT
            Assert.True(result1);
            Assert.Equal(count - 1, await fixture.Context.StringEntries.SelectMany(se => se.Votes).CountAsync());
        }

    }
}
