using UselessCore.Enums.Tag;

namespace UselessCore.Services.Tags.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagType Type { get; set; }
    }
}
