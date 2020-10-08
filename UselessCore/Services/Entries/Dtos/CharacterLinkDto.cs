using UselessCore.Enums;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterLinkDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GameName { get; set; }
        public int GameId { get; set; }
        public int LinkCount { get; set; }
        public bool UserSelected { get; set; }
    }
}
