using System;
using System.Collections.Generic;
using System.Text;

namespace UselessCore.Services.Characters.Dtos
{
    public class BaseCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int? IconImageId { get; set; }
    }
}
