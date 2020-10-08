using UselessCore.Enums.Entries;

namespace UselessAPI.Model.Characters
{
    public class AddRemoveCharacterLink
    {
        public CharacterLinkEntryType LinkEntryType { get; set; }
        public int CharacterId { get; set; }
        public int LinkedCharacterId { get; set; }
    }
}
