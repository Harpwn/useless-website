using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Services.Characters;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterLinkSectionDto : ISection
    {
        public int CharacterId { get; set; }
        public int GameId { get; set; }
        public SectionType Type => SectionType.Character;
        public string Title { get; set; }
        public CharacterLinkEntryType LinkEntryType { get; set; }
        public IEnumerable<CharacterLinkDto> Links { get; set; }
        public IEnumerable<CharacterLinkDto> AvaliableCharacters { get; set; }
        public string Description { get; set; }
    }
}
