using System.Collections.Generic;
using System.Threading.Tasks;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Model.Characters;
using UselessCore.Model.Images;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries;

namespace UselessCore.Services.Characters
{
    public interface ICharacterService
    {
        Task<IEnumerable<BaseCharacterDto>> GetAllAsync(EntityStatus? status = null);
        Task<CharacterDto> GetByIdAsync(int id);
        Task<List<ISection>> GetSectionsAsync(int id, string userId = null);
        Task<bool> EditAsync(CharacterDto character);
        Task<int> AddAsync(CharacterDto character);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BaseCharacterDto>> GetAllForGameAsync(int gameId, EntityStatus? status = null);
    }
}
