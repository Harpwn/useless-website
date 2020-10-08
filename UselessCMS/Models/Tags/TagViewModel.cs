using UselessCore.Enums;
using UselessCore.Enums.Tag;

namespace UselessCMS.Models.Tags
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagType Type { get; set; }
    }
}
