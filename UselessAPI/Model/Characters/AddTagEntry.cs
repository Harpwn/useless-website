using UselessCore.Enums.Entries;

namespace UselessAPI.Model.Characters
{
    public class AddTagEntry
    {
        public CharacterTagEntryType TagEntryType { get; set; }
        public int CharacterId { get; set; }
        public string TagName { get; set; }
    }
}
