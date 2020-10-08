using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UselessAPI.Model.Characters;
using UselessAPI.Model.Games;
using UselessCore.Enums;
using UselessCore.Services.Characters;
using UselessCore.Services.Games;

namespace UselessAPI.Controllers
{
    public class GamesController : ApiControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ICharacterService _characterService;

        public GamesController(IGameService gameService, ICharacterService characterService)
        {
            _gameService = gameService;
            _characterService = characterService;
        }

        public async Task<IActionResult> Index(EntityStatus? status = null)
        {
            var games = await _gameService.GetAllAsync(status);
            return new JsonResult(games.Select(g => new BaseGame
            {
                ID = g.Id,
                Name = g.Name,
                HasSite = g.HasSite,
                GameKey = g.GameKey,
                Status = g.Status,
            }));
        }

        [Route("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var game = await _gameService.GetByIdAsync(id);

            if (game == null)
                return BadRequest(new { message = "Game Doesnt Exist" });

            var characters = (await _characterService.GetAllForGameAsync(id)).ToList();

            if (characters == null || !characters.Any())
                return BadRequest(new { message = "Characters Dont Exist" });

            var apiGame = new Game
            {
                ID = game.Id,
                Name = game.Name,
                HasSite = game.HasSite,
                GameKey = game.GameKey,
                Status = game.Status,
                Characters = characters.Select(c => new BaseCharacter
                {
                    Id = c.Id,
                    GameId = c.GameId,
                    Name = c.Name,
                }).ToList(),
            };

            return new JsonResult(apiGame);
        }

        [Route("Logo/{id}")]
        [ResponseCache(Duration = 604800)]
        public async Task<IActionResult> GameLogo(int id)
        {
            var logo = await _gameService.GetLogoAsync(id);
            
            if (logo != null)
                return File(logo.File, "image/png");

            return StatusCode((int)HttpStatusCode.NotFound);
        }
    }
}