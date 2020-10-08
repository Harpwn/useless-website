using System.Collections.Generic;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCMS.Models.Sections
{
    public class CharacterStringSectionViewModel : ISectionViewModel
    {
        public string Title { get; set; }
        public CharacterStringEntryType StringEntryType { get; set; }
        public IEnumerable<CharacterStringViewModel> Values { get; set; }
        public SectionType Type => SectionType.String;
        public int CharacterId { get; set; }
    }
}
