using UselessCore.Enums.Entries;

namespace UselessAPI.Model.Characters
{
    public class RemoveStringEntry
    {
        public CharacterStringEntryType StringEntryType { get; set; }
        public int CharacterId { get; set; }
        public int EntryId { get; set; }
    }
}
