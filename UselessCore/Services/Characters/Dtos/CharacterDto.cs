using System;
using UselessCore.Enums;
using UselessCore.Model.Images;
using UselessCore.Services.Games;
using UselessCore.Services.Images.Dtos;

namespace UselessCore.Services.Characters.Dtos
{
    public class CharacterDto : BaseCharacterDto
    {
        public int UserCount { get; set; }
        public EntityStatus Status { get; set; }
        public ImageDto IconImage { get; set; }
    }
}
