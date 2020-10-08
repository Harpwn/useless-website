using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Characters;
using UselessCore.Model.Games;
using UselessCore.Services.Characters.Dtos;

namespace UselessCore.Services.Entries
{
    public interface ISectionBuilderFactory
    {
        ISectionBuilder GetSectionBuilder(
            Character character,
            List<BaseCharacterDto> characters,
            string userId = null);
    }
}
