using System.Collections.Generic;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Model.Images;
using UselessCore.Services.Games.Dtos;

namespace UselessCore.Services.Games
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllAsync(EntityStatus? status = null);

        Task<Image> GetLogoAsync(int id);

        Task<GameDto> GetByIdAsync(int id);

        Task<bool> EditAsync(GameDto game);

        Task<int> AddAsync(GameDto game);

        Task<bool> DeleteAsync(int id);
    }
}
