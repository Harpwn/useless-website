using System.Threading.Tasks;
using UselessCore.Model.Images;
using UselessCore.Services.Images.Dtos;

namespace UselessCore.Services.Images
{
    public interface IImageService
    {
        Task<ImageDto> GetByIDAsync(int id);
    }
}
