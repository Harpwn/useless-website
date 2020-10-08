using AutoMapper;
using UselessCore.Services.Games.Dtos;

namespace UselessCMS.Models.Games.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, GameViewModel>();
            CreateMap<GameDto, GameEditViewModel>();
        }
    }
}
