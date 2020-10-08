using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Services.Characters;
using UselessCore.Services.Characters.Dtos;

namespace UselessCore.Services.Games.Dtos
{
    public class GameDetailsDto : GameDto
    {
        public IEnumerable<CharacterDto> Characters { get; set; }
    }
}
