using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Users;
using UselessCore.Services.Users.Dtos;

namespace UselessCore.Model.Users.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
