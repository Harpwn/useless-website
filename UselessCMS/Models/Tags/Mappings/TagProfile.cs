using AutoMapper;
using UselessCore.Services.Tags.Dtos;

namespace UselessCMS.Models.Tags.Mappings
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<TagDto, TagViewModel>();
        }
    }
}
