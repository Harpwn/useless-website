using System;
using System.Collections.Generic;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Model.Images;
using UselessCore.Services.Images.Dtos;

namespace UselessCore.Services.Games.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasSite { get; set; }
        public string GameKey { get; set; }
        public ImageDto GameLogo { get; set; }
        public EntityStatus Status { get; set; }
        public IEnumerable<CharacterValueEntryType> ValueEntryTypes { get; set; } = new List<CharacterValueEntryType>();
        public IEnumerable<CharacterStringEntryType> StringEntryTypes { get; set; } = new List<CharacterStringEntryType>();
        public IEnumerable<CharacterLinkEntryType> LinkEntryTypes { get; set; } = new List<CharacterLinkEntryType>();
        public IEnumerable<CharacterTagEntryType> TagEntryTypes { get; set; } = new List<CharacterTagEntryType>();

    }
}
