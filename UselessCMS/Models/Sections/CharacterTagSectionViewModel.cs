using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCMS.Models.Characters;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCMS.Models.Sections
{
    public class CharacterTagSectionViewModel : ISectionViewModel
    {
        public string Title { get; set; }
        public CharacterTagEntryType TagEntryType { get; set; }
        public IEnumerable<CharacterTagViewModel> Tags { get; set; }
        public SectionType Type => SectionType.Tag;
        public int CharacterId { get; set; }
    }
}
