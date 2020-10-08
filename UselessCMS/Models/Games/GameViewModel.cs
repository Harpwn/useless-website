using UselessCore.Enums;

namespace UselessCMS.Models.Games
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EntityStatus Status { get; set; }
    }
}
