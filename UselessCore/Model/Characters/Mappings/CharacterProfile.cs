using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using UselessCore.Model.Characters;
using UselessCore.Services.Characters;
using UselessCore.Services.Characters.Dtos;

namespace UselessCore.Model.Characters.Mappings
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, BaseCharacterDto>();
            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.UserCount, opt => opt.MapFrom(character => character.LinkEntries.Select(s => s.User.Id)
                    .Union(character.StringEntries.Select(s => s.User.Id))
                    .Union(character.TagEntries.Select(s => s.User.Id))
                    .Union(character.ValueEntries.Select(s => s.User.Id))
                    .Distinct().Count()));
        }
    }
}
