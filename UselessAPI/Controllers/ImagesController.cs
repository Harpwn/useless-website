using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UselessCore.Services.Images;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using UselessCore.Services.Characters;

namespace UselessAPI.Controllers
{
    [Authorize]
    public class ImagesController : ApiControllerBase
    {
        private IImageService _imageService;
        private ICharacterService _characterService;


        public ImagesController(IImageService imageService, ICharacterService characterService)
        {
            _imageService = imageService;
            _characterService = characterService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [ResponseCache(Duration = 604800)]
        public async Task<IActionResult> Index(int id)
        {
            var image = await _imageService.GetByIDAsync(id);

            if (image != null)
                return File(image.File, "image/png");

            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [AllowAnonymous]
        [Route("Icons")]
        [ResponseCache(Duration = 604800)]
        public async Task<IActionResult> Icons()
        {
            var ids = new List<int>();
            ids.AddRange((await _characterService.GetAllAsync()).Where(c => c.IconImageId.HasValue).Select(f => f.IconImageId.Value).ToList());
            return new JsonResult(ids);
        }

    }
}
