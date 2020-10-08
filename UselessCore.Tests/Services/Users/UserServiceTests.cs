using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Model.Users;
using UselessCore.Services.Users;
using UselessCore.Services.Users.Dtos;
using UselessCore.Tests.Fixtures;
using UselessTestingCore.Mocks.Identity;
using Xunit;

namespace UselessCore.Tests.Services.Users
{
    public class UserServiceTests : IClassFixture<DatabaseFixture>
    {
        UserService service;
        DatabaseFixture fixture;
        IMapper mapper;

        public UserServiceTests(DatabaseFixture fixture)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            mapper = new Mapper(configuration);

            var mockMemoryCache = new Mock<IMemoryCache>();
            this.fixture = fixture;
            service = new UserService(fixture.Context,new FakeUserManager(), mockMemoryCache.Object, mapper);
        }


        [Fact]
        public async Task AuthenticateAsync_ReturnsNull_WhenInvalidInput()
        {
            //ARRANGE
            var dto = new AuthUserDto() { UserName = "test", Password = "" };
            var dto2 = new AuthUserDto() { UserName = "", Password = "test" };
            var dto3 = new AuthUserDto() { UserName = "test", Password = null };
            var dto4 = new AuthUserDto() { UserName = null, Password = "test" };

            //ACT
            var result = await service.AuthenticateAsync(dto);
            var result2 = await service.AuthenticateAsync(dto2);
            var result3 = await service.AuthenticateAsync(dto3);
            var result4 = await service.AuthenticateAsync(dto4);

            //ASSERT
            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
            Assert.False(result3.Succeeded);
            Assert.False(result4.Succeeded);
        }

        [Fact]
        public async Task AuthenticateAsync_ReturnsNull_WhenUserDoesntExist()
        {
            //ARRANGE
            var dto = new AuthUserDto() { UserName = "test", Password = "testpass" };

            //ACT
            var result = await service.AuthenticateAsync(dto);

            //ASSERT
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task AuthenticateAsync_ReturnsNull_WhenPasswordWrong()
        {
            //ARRANGE
            var dto = new AuthUserDto() { UserName = "John", Password = "wrongpassword" };

            //ACT
            var result = await service.AuthenticateAsync(dto);

            //ASSERT
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task AuthenticateAsync_ReturnsUserDto()
        {
            //ARRANGE
            var dto = new AuthUserDto() { UserName = "John", Password = "password" };

            //ACT
            var result = await service.AuthenticateAsync(dto);

            //ASSERT
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task CreateAsync_Fails_WhenInvalidInput()
        {
            //ARRANGE
            var dto = new RegisterUserDto() { UserName = "John", Password = "" };
            var dto2 = new RegisterUserDto() { UserName = "", Password = "test" };
            var dto3 = new RegisterUserDto() { Password = "" };
            var dto4 = new RegisterUserDto() { UserName = "" };

            //ACT
            var result = await service.CreateAsync(dto);
            var result2 = await service.CreateAsync(dto2);
            var result3 = await service.CreateAsync(dto3);
            var result4 = await service.CreateAsync(dto4);

            //ASSERT
            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
            Assert.False(result3.Succeeded);
            Assert.False(result4.Succeeded);
        }

        [Fact]
        public async Task CreateAsync_Fails_WhenUserExists()
        {
            //ARRANGE
            var dto = new RegisterUserDto() { UserName = "John", Password = "test" };

            //ACT
            var result = await service.CreateAsync(dto);

            //ASSERT
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task CreateAsync_Succeeds_WhenValidInput()
        {
            //ARRANGE
            var dto = new RegisterUserDto() { UserName = "John2", Password = "test" };

            //ACT
            var result = await service.CreateAsync(dto);

            //ASSERT
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesUsers()
        {
            //ARRANGE
            var testDisplayName = "test123";
            var dto = new UserDto() { Id = "1", UserName = "John", Email = "test2", DisplayName = testDisplayName };

            //ACT
            var result = await service.UpdateAsync(dto);

            //ASSERT
            Assert.True(result.Succeeded);
            Assert.NotNull(result.User);
            Assert.Equal(testDisplayName, result.User.DisplayName);
        }

        [Fact]
        public async Task UpdateAsync_Fails_WhenInvalidInput()
        {
            //ARRANGE
            var dto = new UserDto() { UserName = "John" };
            var dto2 = new UserDto() { Id = "1" };

            //ACT
            var result = await service.UpdateAsync(dto);
            var result2 = await service.UpdateAsync(dto2);

            //ASSERT
            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public async Task UpdateAsync_Fails_WhenUserDoesntExist()
        {
            //ARRANGE
            var dto = new UserDto() { Id = "2", UserName = "John", Email = "test2" };

            //ACT
            var result = await service.UpdateAsync(dto);

            //ASSERT
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task UpdateAsync_Fails_WhenNewUserNameDisplayNameExists()
        {
            //ARRANGE
            var user = new User { UserName = "John", Email = "test2@test.com" };
            var user2 = new User { UserName = "John2", Email = "test1@test.com", DisplayName = "John" };
            fixture.Context.Users.Add(user);
            fixture.Context.Users.Add(user2);
            fixture.Context.SaveChanges();
            var dto = new UserDto() { Id = "1" , UserName = "John2", Email = "test2@test.com" };
            var dto2 = new UserDto() { Id = "1", UserName = "John", Email = "test2@test.com", DisplayName = "John" };

            //ACT
            var result = await service.UpdateAsync(dto);
            var result2 = await service.UpdateAsync(dto2);

            //ASSERT
            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public async Task DeleteAsync_Deletes()
        {
            //ARRANGE
            var userId = "1";

            //ACT
            var result = await service.DeleteAsync(userId);

            //ASSERT
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task DeleteAsync_Fails_WhenUserNotExists()
        {
            //ARRANGE
            var userId = "2";

            //ACT
            var result = await service.DeleteAsync(userId);

            //ASSERT
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task ChangePasswordAsync_ChangesPassword()
        {
            //ARRANGE
            var dto = new ChangePasswordDto { Id = "1", UserName = "John", Password = "password", NewPassword = "password1" };

            //ACT
            var result = await service.ChangePasswordAsync(dto);

            //ASSERT
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task ChangePasswordAsync_Fails_WhenUserNotExists()
        {
            //ARRANGE
            var dto = new ChangePasswordDto { Id = "2", UserName = "John", Password = "password", NewPassword = "password1" };

            //ACT
            var result = await service.ChangePasswordAsync(dto);

            //ASSERT
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task GetByIDAsync_Succeeds_WhenUserExists()
        {
            //ARRANGE
            var userId = "1";

            //ACT
            var result = await service.GetByIDAsync(userId);

            //ASSERT
            Assert.True(result.Succeeded);
            Assert.NotNull(result.User);
        }

        [Fact]
        public async Task GetByIDAsync_Fails_WhenUserDoesntExist()
        {
            //ARRANGE
            var userId = "2";

            //ACT
            var result = await service.GetByIDAsync(userId);

            //ASSERT
            Assert.False(result.Succeeded);
            Assert.Null(result.User);
        }
    }
}
