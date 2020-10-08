using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UselessCMS.Models;
using UselessCMS.Models.Games;
using UselessCore.Services.Games;
using UselessCore.Services.Games.Dtos;
using UselessCore.Services.Images.Dtos;

namespace UselessCMS.Controllers
{
    public class GameController : MasterController
    {

        private IGameService _gameService;

        public GameController(IGameService gameService, IMapper mapper) : base(mapper)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new GamesPageViewModel()
            {
                Games = (await _gameService.GetAllAsync()).Select(g => _mapper.Map<GameViewModel>(g)).OrderBy(g => g.Name).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetByIdAsync(id);

            if (game == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var model = new GameEditViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                HasSite = game.HasSite,
                GameKey = game.GameKey,
                Status = game.Status,
                HasLogo = game.GameLogo != null,
                ValueEntryTypes = game.ValueEntryTypes,
                LinkEntryTypes = game.LinkEntryTypes,
                StringEntryTypes = game.StringEntryTypes,
                TagEntryTypes = game.TagEntryTypes
            };

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new GameEditViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (vm.Id.HasValue)
            {
                var game = await _gameService.GetByIdAsync(vm.Id.Value);
                if (game == null)
                    return StatusCode((int)HttpStatusCode.NotFound);

                game.Name = vm.Name;
                game.Status = vm.Status;
                game.HasSite = vm.HasSite;
                game.GameKey = vm.GameKey;
                game.LinkEntryTypes = vm.LinkEntryTypes;
                game.StringEntryTypes = vm.StringEntryTypes;
                game.ValueEntryTypes = vm.ValueEntryTypes;
                game.TagEntryTypes = vm.TagEntryTypes;

                if (vm.GameLogo != null)
                {
                    if (game.GameLogo != null)
                    {
                        game.GameLogo.File = vm.GameLogo.Getbytes();
                        game.GameLogo.LastModified = DateTime.UtcNow;
                    }
                    else
                    {
                        game.GameLogo = new ImageDto() { File = vm.GameLogo.Getbytes() };
                    }
                }


                await _gameService.EditAsync(game);

            }
            else
            {
                var game = new GameDto()
                {
                    Name = vm.Name,
                    HasSite = vm.HasSite,
                    GameKey = vm.GameKey,
                    Status = vm.Status,
                    GameLogo = vm.GameLogo != null ? new ImageDto() { File = vm.GameLogo.Getbytes() } : null,
                    StringEntryTypes = vm.StringEntryTypes,
                    ValueEntryTypes = vm.ValueEntryTypes,
                    LinkEntryTypes = vm.LinkEntryTypes,
                    TagEntryTypes = vm.TagEntryTypes
                };

                await _gameService.AddAsync(game);
            }

            return RedirectToAction("Index", "Game");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 604800)]
        public async Task<IActionResult> GameLogo(int id)
        {
            var game = await _gameService.GetByIdAsync(id);

            if (game != null && game.GameLogo != null)
                return File(game.GameLogo.File, "image/png");

            return StatusCode((int)HttpStatusCode.NotFound);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetByIdAsync(id);

            if (game == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            await _gameService.DeleteAsync(id);


            return RedirectToAction("Index", "Game");
        }
    }
}
