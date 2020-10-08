using System.Collections.Generic;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCMS.Models.Sections
{
    public class CharacterValueSectionViewModel : ISectionViewModel
    {
        public string Title { get; set; }
        public CharacterValueEntryType ValueEntryType { get; set; }
        public IEnumerable<CharacterValueViewModel> Values { get; set; }
        public SectionType Type => SectionType.Value;
        public int CharacterId { get; set; }
    }
}
