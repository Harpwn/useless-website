using System.Collections.Generic;
using UselessCore.Enums;
using UselessCore.Services.Entries;

namespace UselessAPI.Model.Characters
{
    public class Character : BaseCharacter
    {
        public int UserCount { get; set; }
        public EntityStatus Status { get; set; }
        public IList<ISection> Sections { get; set; } = new List<ISection>();
    }
}
