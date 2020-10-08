using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Tags;
using UselessCore.Services.Tags.Dtos;

namespace UselessCore.Model.Tags.Mappings
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>();
        }
    }
}
