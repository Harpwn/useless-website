using System.Collections.Generic;
using UselessCore.Enums.Tag;
using UselessCore.Model.Entries;

namespace UselessCore.Model.Tags
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public TagType Type  { get; set; }
        public virtual ICollection<CharacterTagEntry> TagEntries { get; set; } = new List<CharacterTagEntry>();
    }
}
