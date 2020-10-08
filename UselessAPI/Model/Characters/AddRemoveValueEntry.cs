using UselessCore.Enums.Entries;

namespace UselessAPI.Model.Characters
{
    public class AddRemoveValueEntry
    {
        public CharacterValueEntryType ValueEntryType { get; set; }
        public int CharacterId { get; set; }
        public int Value { get; set; }
    }
}
