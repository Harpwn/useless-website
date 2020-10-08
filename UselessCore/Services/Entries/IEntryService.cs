using System.Threading.Tasks;
using UselessCore.Enums.Entries;

namespace UselessCore.Services.Entries
{
    public interface IEntryService
    {
        Task<bool> AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType type, string userId, int characterId, int linkedCharacterId);
        Task<bool> RemoveCharacterLinkEntryAsync(CharacterLinkEntryType type, string userId, int characterId, int linkedCharacterId);
        Task<bool> AddReplaceCharacterTagEntryAsync(CharacterTagEntryType type, string userId, int characterId, string tagText);
        Task<bool> RemoveCharacterTagEntryAsync(CharacterTagEntryType type, string userId, int characterId, int tagId);
        Task<bool> AddReplaceCharacterValueEntryAsync(CharacterValueEntryType type, string userId, int characterId, int value);
        Task<bool> RemoveCharacterValueEntryAsync(CharacterValueEntryType type, string userId, int characterId, int value);
        Task<bool> AddReplaceCharacterStringEntryAsync(CharacterStringEntryType type, string userId, int characterId, string text);
        Task<bool> RemoveCharacterStringEntryAsync(CharacterStringEntryType type, string userId, int characterId, int entryId);
        Task<bool> AddCharacterStringEntryVoteAsync(CharacterStringEntryType type, string userId, int characterId, int entryId);
        Task<bool> RemoveCharacterStringEntryVoteAsync(CharacterStringEntryType type, string userId, int characterId, int entryId);
    }
}
