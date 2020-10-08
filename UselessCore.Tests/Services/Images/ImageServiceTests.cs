using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Model.Images;
using UselessCore.Services.Images;
using UselessCore.Tests.Fixtures;
using Xunit;

namespace UselessCore.Tests.Services.Images
{
    public class ImageServiceTests : IClassFixture<DatabaseFixture>
    {
        ImageService service;
        DatabaseFixture fixture;
        IMapper mapper;

        public ImageServiceTests(DatabaseFixture fixture)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "UselessCore",
                })
            );

            mapper = new Mapper(configuration);

            var mockMemoryCache = new Mock<IMemoryCache>();
            this.fixture = fixture;
            service = new ImageService(fixture.Context, mockMemoryCache.Object, mapper);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsImage()
        {
            //ARRANGE
            var image = new Image { File = new byte[0] };
            fixture.Context.Images.Add(image);
            fixture.Context.SaveChanges();

            //ACT
            var result = await service.GetByIDAsync(image.Id);

            //ASSERT
            Assert.Equal(result.Id, image.Id);
        }

        [Fact]
        public async Task GetByIDAsync_ReturnsNull_WhenGameDoesntExist()
        {
            //ARRANGE
            var imageID = 999;

            //ACT
            var result = await service.GetByIDAsync(imageID);

            //ASSERT
            Assert.Null(result);
        }

    }
}
