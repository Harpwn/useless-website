using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using UselessCore.Model;
using UselessCore.Model.Images;
using UselessCore.Services.Images.Dtos;

namespace UselessCore.Services.Images
{
    public class ImageService : Service, IImageService
    {
        public ImageService(UselessContext context, IMemoryCache cache, IMapper mapper) : base(context, cache, mapper)
        {
        }

        public async Task<ImageDto> GetByIDAsync(int id)
        {
            var image = await Context.Images.FindAsync(id);
            if (image == null)
                return null;

            return Mapper.Map<ImageDto>(image);
        }
    }
}
