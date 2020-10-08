using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Games;
using UselessCore.Services.Games.Dtos;

namespace UselessCore.Model.Games.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<Game, GameDetailsDto>();
        }
    }
}
