using UselessCore.Enums;

namespace UselessAPI.Model.Games
{
    public class BaseGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool HasSite { get; set; }
        public string GameKey { get; set; }
        public EntityStatus Status { get; set; }
    }
}
