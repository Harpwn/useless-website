using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UselessCMS.Models.Tags;
using UselessCore.Services.Tags;
using UselessCore.Services.Tags.Dtos;

namespace UselessCMS.Controllers
{
    public class TagController : MasterController
    {
        private ITagService _tagService;

        public TagController(ITagService tagService, IMapper mapper) : base(mapper)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetAllAsync();

            var model = new TagsPageViewModel()
            {
                Tags = _mapper.Map<List<TagViewModel>>(tags.OrderBy(t => t.Name))
            };

            return View(model);
        }

        public async Task<IActionResult> Add(string tagName)
        {
            if(!string.IsNullOrEmpty(tagName))
            {
                await _tagService.TryCreateAsync(new TagDto
                {
                    Name = tagName,
                    Type = UselessCore.Enums.Tag.TagType.System
                });
            }

            return RedirectToAction("Index", "Tag");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _tagService.GetByIDAsync(id);

            if (tag == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            await _tagService.TryDeleteAsync(id);


            return RedirectToAction("Index", "Tag");
        }
    }
}
