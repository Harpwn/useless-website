using System;
using UselessCore.Enums.Tag;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterTagDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TagType Type { get; set; }
        public int TagCount { get; set; }
        public bool UserSelected { get; set; }
        public long Timestamp { get; set; }
    }
}
