using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Model;
using UselessCore.Model.Tags;
using UselessCore.Services.Tags.Dtos;

namespace UselessCore.Services.Tags
{
    public class TagService : Service, ITagService
    {
        public TagService(UselessContext context, IMemoryCache cache, IMapper mapper) : base(context, cache, mapper)
        {
        }

        public async Task<IEnumerable<TagDto>> GetAllAsync()
        {
            return await Mapper.ProjectTo<TagDto>(Context.Tags).ToListAsync();
        }

        public async Task<Tag> GetOrCreateTagAsync(string tagName)
        {
            var tag = await Context.Tags.SingleOrDefaultAsync(t => t.Name == tagName.ToUpper());

            if(tag == null)
            {
                tag = new Tag
                {
                    Name = tagName.ToUpper(),
                    Type = Enums.Tag.TagType.UserGenerated
                };

                Context.Tags.Add(tag);
                await Context.SaveChangesAsync();
            }

            return tag;
        }

        public async Task<int> TryCreateAsync(TagDto tag)
        {
            var existingTag = await Context.Tags.SingleOrDefaultAsync(t => t.Name == tag.Name.ToUpper());

            if (existingTag == null)
            {
                var newTag = new Tag
                {
                    Name = tag.Name.ToUpper(),
                    Type = tag.Type
                };
                Context.Add(newTag);

                await Context.SaveChangesAsync();
                return newTag.Id;
            }

            return existingTag.Id;
        }

        public async Task<bool> TryDeleteAsync(int id)
        {
            var tag = await Context.Tags.FindAsync(id);

            if (tag != null && !tag.TagEntries.Any())
            {
                Context.Tags.Remove(tag);
                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<TagDto> GetByIDAsync(int id)
        {
            var tag = await Context.Tags.FindAsync(id);
            if (tag == null)
                return null;

            return Mapper.Map<TagDto>(tag);
        }

        public async Task<IEnumerable<TagDto>> SearchAsync(string searchText)
        {
            return await Mapper.ProjectTo<TagDto>(Context.Tags.Where(t => t.Name.Contains(searchText)).OrderBy(t => t.Name.Length)).ToListAsync();
        }
    }
}
