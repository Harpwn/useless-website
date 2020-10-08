using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Characters;
using UselessCore.Services.Characters.Dtos;

namespace UselessCore.Services.Entries
{
    public class SectionBuilderFactory : ISectionBuilderFactory
    {
        public ISectionBuilder GetSectionBuilder(
            Character character, 
            List<BaseCharacterDto> characters, 
            string userId = null)
        {
            return new SectionBuilder(character, characters, userId);
        }
    }
}
