using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model.Images;
using UselessCore.Services.Images.Dtos;

namespace UselessCore.Model.Images.Mappings
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>();
        }
    }
}
