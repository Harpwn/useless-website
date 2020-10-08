using UselessCore.Enums;

namespace UselessCMS.Models.Characters
{
    public class CharacterViewModel : BaseCharacterViewModel
    {
        public string GameName { get; set; }
        public EntityStatus Status { get; set; }
    }
}
