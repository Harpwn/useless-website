using System;
using System.Collections.Generic;
using System.Text;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterStringDto
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string CreatorDisplayName { get; set; }
        public int? CreatorAvatarIcon { get; set; }
        public int ValueCount { get; set; }
        public bool UserSelected { get; set; }
        public bool UserCreated { get; set; }
    }
}
