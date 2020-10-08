using UselessCore.Enums.Entries;

namespace UselessAPI.Model.Characters
{
    public class RemoveTagEntry
    {
        public CharacterTagEntryType TagEntryType { get; set; }
        public int CharacterId { get; set; }
        public int TagId { get; set; }
    }
}
