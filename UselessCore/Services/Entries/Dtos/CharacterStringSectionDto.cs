using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterStringSectionDto : ISection
    {
        public int CharacterId { get; set; }
        public int GameId { get; set; }
        public SectionType Type => SectionType.String;
        public string Title { get; set; }
        public CharacterStringEntryType StringEntryType { get; set; }
        public IEnumerable<CharacterStringDto> Values { get; set; }
        public string Description { get; set; }
    }
}
