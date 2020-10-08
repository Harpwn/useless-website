using System;
using System.Collections.Generic;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterValueSectionDto : ISection
    {
        public int CharacterId { get; set; }
        public int GameId { get; set; }
        public SectionType Type => SectionType.Value;
        public string Title { get; set; }
        public CharacterValueEntryType ValueEntryType { get; set; }
        public IEnumerable<CharacterValueDto> Values { get; set; }
        public string Description { get; set; }
    }
}
