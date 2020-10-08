using UselessCore.Enums;

namespace UselessCMS.Models.Sections
{
    public interface ISectionViewModel
    {
        int CharacterId { get; set; }
        string Title { get; set; }
        SectionType Type { get; }
    }
}
