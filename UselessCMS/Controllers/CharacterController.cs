using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UselessCMS.Models;
using UselessCMS.Models.Characters;
using UselessCMS.Models.Games;
using UselessCMS.Models.Sections;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Services.Characters;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries;
using UselessCore.Services.Games;
using UselessCore.Services.Images.Dtos;

namespace UselessCMS.Controllers
{
    public class CharacterController : MasterController
    {
        private ICharacterService _characterService;
        private IGameService _gameService;
        private IEntryService _entryService;

        public CharacterController(ICharacterService characterService, IGameService gameService, IEntryService entryService, IMapper mapper) : base(mapper)
        {
            _characterService = characterService ?? throw new ArgumentNullException(nameof(characterService));
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _entryService = entryService ?? throw new ArgumentNullException(nameof(entryService));
        }

        public async Task<IActionResult> ListByGame(int Id)
        {
            var game = await _gameService.GetByIdAsync(Id);

            if (game == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var characters = (await _characterService.GetAllForGameAsync(Id)).ToList();

            var model = new GameCharactersPageViewModel()
            {
                Game = _mapper.Map<GameViewModel>(game),
                Characters = _mapper.Map<List<BaseCharacterDto>,List<BaseCharacterViewModel>>(characters).OrderBy(c => c.Name).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var character = await _characterService.GetByIdAsync(id);

            if (character == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var model = _mapper.Map<CharacterEditViewModel>(character);
            return View(model);
        }

        public IActionResult Add(int gameId)
        {
            var model = new CharacterEditViewModel()
            {
                GameId = gameId,
            };

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CharacterEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var game = await _gameService.GetByIdAsync(vm.GameId);
            if (game == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            if (vm.Id.HasValue)
            {
                var character = await _characterService.GetByIdAsync(vm.Id.Value);
                if (character == null)
                    return StatusCode((int)HttpStatusCode.NotFound);

                character.Name = vm.Name;
                character.Status = vm.Status;

                if (vm.IconImage != null)
                {
                    if (character.IconImage != null)
                    {
                        character.IconImage.File = vm.IconImage.Getbytes();
                        character.IconImage.LastModified = DateTime.UtcNow;
                    }
                    else
                    {
                        character.IconImage = new ImageDto { File = vm.IconImage.Getbytes() };
                    }
                }


                await _characterService.EditAsync(character);
            }
            else
            {
                var character =  new CharacterDto()
                {
                    Name = vm.Name,
                    IconImage = vm.IconImage != null ? new ImageDto { File = vm.IconImage.Getbytes() } : null,
                    Status = vm.Status,
                    GameId = game.Id
                };
                await _characterService.AddAsync(character);
            }

            return RedirectToAction("ListByGame", "Character", new { id = vm.GameId });
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 604800)]
        public async Task<IActionResult> IconImage(int id)
        {
            var character = await _characterService.GetByIdAsync(id);

            if (character != null && character.IconImage != null)
                return File(character.IconImage.File, "image/png");

            return StatusCode((int)HttpStatusCode.NotFound);
        }

        public async Task<IActionResult> Delete(int id, int gameId)
        {
            var character = await _characterService.GetByIdAsync(id);
            if (character == null)
                return StatusCode((int)HttpStatusCode.NotFound);


            await _characterService.DeleteAsync(id);
            return RedirectToAction("ListByGame", "Character", new { id = gameId });
        }

        public async Task<IActionResult> Index(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var character = await _characterService.GetByIdAsync(id);
            var sections = await _characterService.GetSectionsAsync(id, userId);

            if (character == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var model = new CharacterPageViewModel
            {
                Character = _mapper.Map<CharacterViewModel>(character),
                Sections = sections.Select(s => s.Translate())
            };

            return View(model);
        }

        public async Task<IActionResult> AddCharacterLinkEntry(CharacterLinkEntryType entryType, int id, int linkId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.AddReplaceCharacterLinkEntryAsync(entryType, userId, id, linkId);
            return RedirectToAction("Index", new { id = id });
        }

        public async Task<IActionResult> RemoveCharacterLinkEntry(CharacterLinkEntryType entryType, int id, int linkId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.RemoveCharacterLinkEntryAsync(entryType, userId, id, linkId);
            return RedirectToAction("Index", new { id = id });
        }

        public async Task<IActionResult> AddTagEntry(CharacterTagEntryType entryType, int id, string tagName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.AddReplaceCharacterTagEntryAsync(entryType, userId, id, tagName);
            return RedirectToAction("Index", new { id = id });
        }
        public async Task<IActionResult> RemoveTagEntry(CharacterTagEntryType entryType, int id, int tagId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.RemoveCharacterTagEntryAsync(entryType, userId, id, tagId);
            return RedirectToAction("Index", new { id = id });
        }

        public async Task<IActionResult> AddValueEntry(CharacterValueEntryType entryType, int id, int valueVal)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.AddReplaceCharacterValueEntryAsync(entryType, userId, id, valueVal);
            return RedirectToAction("Index", new { id = id });
        }
        public async Task<IActionResult> RemoveValueEntry(CharacterValueEntryType entryType, int id, int val)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.RemoveCharacterValueEntryAsync(entryType, userId, id, val);
            return RedirectToAction("Index", new { id = id });
        }

        public async Task<IActionResult> AddStringEntry(CharacterStringEntryType entryType, int id, string text)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrWhiteSpace(text))
            {
                await _entryService.AddReplaceCharacterStringEntryAsync(entryType, userId, id, text);
            }

            return RedirectToAction("Index", new { id = id });
        }
        public async Task<IActionResult> RemoveStringEntry(CharacterStringEntryType entryType, int id, int entryId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.RemoveCharacterStringEntryAsync(entryType, userId, id, entryId);
            return RedirectToAction("Index", new { id = id });
        }

        public async Task<IActionResult> AddStringEntryVote(CharacterStringEntryType entryType, int id, int entryId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.AddCharacterStringEntryVoteAsync(entryType, userId, id, entryId);
            return RedirectToAction("Index", new { id = id });
        }
        public async Task<IActionResult> RemoveStringEntryVote(CharacterStringEntryType entryType, int id, int entryId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _entryService.RemoveCharacterStringEntryVoteAsync(entryType, userId, id, entryId);
            return RedirectToAction("Index", new { id = id });
        }

    }
}