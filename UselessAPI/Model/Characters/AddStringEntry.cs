using UselessCore.Enums.Entries;

namespace UselessAPI.Model.Characters
{
    public class AddStringEntry
    {
        public CharacterStringEntryType StringEntryType { get; set; }
        public int CharacterId { get; set; }
        public string Text { get; set; }
    }
}
