using UselessCore.Enums;

namespace UselessCore.Services.Entries
{
    public interface ISection
    {
        int CharacterId { get; set; }
        string Title { get; set; }
        SectionType Type { get; }
        string Description { get; set; }
    }
}
