using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCMS.Models.Games;

namespace UselessCMS.Models.Characters
{
    public class GameCharactersPageViewModel : MasterViewModel
    {
        public GameViewModel Game { get; set; }
        public List<BaseCharacterViewModel> Characters { get; set; } = new List<BaseCharacterViewModel>();
    }
}
