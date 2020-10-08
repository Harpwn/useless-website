using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Model.Characters;
using UselessCore.Model.Games;
using UselessCore.Model.Users;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries;
using UselessCore.Tests.Fixtures;
using Xunit;

namespace UselessCore.Tests.Services.Entries
{
    public class SectionBuilderTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;
        IMapper mapper;

        public SectionBuilderTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            var user = new User { Email = "test@test.com", UserName = "testuser" };
            var game = new Game { Name = "Test", Status = EntityStatus.Archived };
            var character1 = new Character { Name = "Test1", Status = EntityStatus.Active, Game = game };
            var character2 = new Character { Name = "Test2", Status = EntityStatus.Archived, Game = game };
            fixture.Context.Characters.Add(character1);
            fixture.Context.Characters.Add(character2);
            fixture.Context.Users.Add(user);
            fixture.Context.SaveChanges();

            var configuration = new MapperConfiguration(cfg =>
               cfg.AddMaps(new[] {
                    "UselessCore",
               })
           );

            mapper = new Mapper(configuration);
        }


        [Fact]
        public async Task Builder_BuildsSections_WhenNoUserSupplied()
        {
            //ARRANGE
            var characters = await fixture.Context.Characters.ToListAsync();
            var characterDtos = new List<BaseCharacterDto> { mapper.Map<BaseCharacterDto>(characters[1]) };
            var builder = new SectionBuilder(characters[0],characterDtos);

            //ACT
            builder.BuildMainTagSection();
            builder.BuildTierSection();
            builder.BuildTipsSection();
            builder.BuildSimilarInGameSection();
            builder.BuildSimilarInGenreSection();
            builder.BuildCounteredBySection();
            builder.BuildStrongAgainstSection();
            builder.BuildSynergizesWithSection();

            var result =  builder.GetResult();

            //ASSERT
            Assert.NotNull(result);
            Assert.True(result.Count == 7);
        }

        [Fact]
        public async Task Builder_BuildsSections_WhenUserDoesntExist()
        {
            //ARRANGE
            var user = await fixture.Context.Users.FirstAsync();
            var characters = await fixture.Context.Characters.ToListAsync();
            var characterDtos = new List<BaseCharacterDto> { mapper.Map<BaseCharacterDto>(characters[1]) };
            var builder = new SectionBuilder(characters[0], characterDtos, user.Id);

            //ACT
            builder.BuildMainTagSection();
            builder.BuildTierSection();
            builder.BuildTipsSection();
            builder.BuildSimilarInGameSection();
            builder.BuildSimilarInGenreSection();
            builder.BuildCounteredBySection();
            builder.BuildStrongAgainstSection();
            builder.BuildSynergizesWithSection();

            var result = builder.GetResult();

            //ASSERT
            Assert.NotNull(result);
            Assert.True(result.Count == 7);
        }

        [Fact]
        public async Task Builder_BuildsSections_WhenUseExists()
        {
            //ARRANGE
            var user = new User
            {
                Email = "test@test.com",
                UserName = "testuser"
            };

            string userId = Guid.NewGuid().ToString();
            var characters = await fixture.Context.Characters.ToListAsync();
            var characterDtos = new List<BaseCharacterDto> { mapper.Map<BaseCharacterDto>(characters[1]) };
            var builder = new SectionBuilder(characters[0], characterDtos, userId);

            //ACT
            builder.BuildMainTagSection();
            builder.BuildTierSection();
            builder.BuildTipsSection();
            builder.BuildSimilarInGameSection();
            builder.BuildSimilarInGenreSection();
            builder.BuildCounteredBySection();
            builder.BuildStrongAgainstSection();
            builder.BuildSynergizesWithSection();

            var result = builder.GetResult();

            //ASSERT
            Assert.NotNull(result);
            Assert.True(result.Count == 7);
        }
    }
}
