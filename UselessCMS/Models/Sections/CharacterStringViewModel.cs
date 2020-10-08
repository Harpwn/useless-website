namespace UselessCMS.Models.Sections
{
    public class CharacterStringViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string CreatedByUserName { get; set; }
        public int ValueCount { get; set; }
        public bool UserSelected { get; set; }
        public bool UserCreated { get; set; }
    }
}
