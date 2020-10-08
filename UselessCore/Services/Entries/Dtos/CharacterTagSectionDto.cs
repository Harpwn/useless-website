using System.Collections.Generic;
using UselessCore.Enums;
using UselessCore.Enums.Entries;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterTagSectionDto : ISection
    {
        public int CharacterId { get; set; }
        public int GameId { get; set; }
        public SectionType Type => SectionType.Tag;
        public string Title { get; set; }
        public string Description { get; set; }
        public CharacterTagEntryType TagEntryType { get; set; }
        public IEnumerable<CharacterTagDto> Tags { get; set; }
        
    }
}
