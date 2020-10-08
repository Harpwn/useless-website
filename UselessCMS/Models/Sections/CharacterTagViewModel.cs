using UselessCore.Enums.Tag;

namespace UselessCMS.Models.Sections
{
    public class CharacterTagViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TagType Type { get; set; }
        public bool UserHasSelected { get; set; }
        public int TagCount { get; set; }
    }
}
