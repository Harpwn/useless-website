using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCMS.Models.Characters;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCMS.Models.Sections
{
    public class CharacterLinkSectionViewModel : ISectionViewModel
    {
        public string Title { get; set; }
        public CharacterLinkEntryType LinkType { get; set; }
        public IEnumerable<CharacterLinkViewModel> Links { get; set; }
        public SectionType Type => SectionType.Character;
        public IEnumerable<CharacterSelectionViewModel> AvaliableCharacters { get; set; }
        public int CharacterId { get; set; }
    }
}
