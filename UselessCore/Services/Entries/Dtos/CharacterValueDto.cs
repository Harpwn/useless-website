using UselessCore.Enums;

namespace UselessCore.Services.Entries.Dtos
{
    public class CharacterValueDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ValueCount { get; set; }
        public bool UserSelected { get; set; }
    }
}
