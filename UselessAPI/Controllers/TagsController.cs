using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Services.Tags;

namespace UselessAPI.Controllers
{
    public class TagsController : ApiControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Search(string searchText)
        {
            if (!string.IsNullOrWhiteSpace(searchText) && searchText.Length > 2)
            {
                var tags = await _tagService.SearchAsync(searchText);
                return new JsonResult(tags.Select(t => new { label = t.Name, value = t.Name }));
            }

            return BadRequest(new { message = "Invalid Search" });
        }
    }
}
