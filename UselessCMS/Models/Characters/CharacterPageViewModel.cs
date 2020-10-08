using System.Collections.Generic;
using UselessCMS.Models.Sections;

namespace UselessCMS.Models.Characters
{
    public class CharacterPageViewModel
    {
        public CharacterViewModel Character { get; set; }
        public IEnumerable<ISectionViewModel> Sections { get; set; }
    }
}
