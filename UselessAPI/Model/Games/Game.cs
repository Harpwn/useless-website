using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessAPI.Model.Characters;
using UselessCore.Enums;

namespace UselessAPI.Model.Games
{
    public class Game : BaseGame
    {
        public List<BaseCharacter> Characters { get; set; }
    }
}
