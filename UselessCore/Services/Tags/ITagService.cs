using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Model.Tags;
using UselessCore.Services.Tags.Dtos;

namespace UselessCore.Services.Tags
{
    public interface ITagService
    {
        Task<Tag> GetOrCreateTagAsync(string tagName);
        Task<int> TryCreateAsync(TagDto tag);
        Task<bool> TryDeleteAsync(int id);
        Task<TagDto> GetByIDAsync(int id);
        Task<IEnumerable<TagDto>> GetAllAsync();
        Task<IEnumerable<TagDto>> SearchAsync(string searchText);
    }
}
