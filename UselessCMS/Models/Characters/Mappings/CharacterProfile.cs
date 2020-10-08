using AutoMapper;
using UselessCore.Services.Characters.Dtos;

namespace UselessCMS.Models.Characters.Mappings
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<BaseCharacterDto, BaseCharacterViewModel>();
            CreateMap<CharacterDto, CharacterViewModel>();
            CreateMap<CharacterDto, CharacterEditViewModel>()
                .ForMember(dest => dest.IconImage, opt => opt.Ignore())
                .ForMember(dest => dest.HasIcon, opt => opt.MapFrom(src => src.IconImageId != null));
        }
    }
}
