using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UselessAPI.Model.Characters;
using UselessCore.Enums;
using UselessCore.Services.Characters;
using UselessCore.Services.Entries;

namespace UselessAPI.Controllers
{
    [Route("api/games/{gameId:int}/characters")]
    public class CharactersController : ApiControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IEntryService _entryService;

        public CharactersController(ICharacterService characterService, IEntryService entryService)
        {
            _characterService = characterService;
            _entryService = entryService;
        }

        public async Task<IActionResult> Index(int gameId, EntityStatus? status = null)
        {
            var characters = (await _characterService.GetAllForGameAsync(gameId, status)).ToList();
            return new JsonResult(characters);
        }

        [Route("{id}")]
        public async Task<IActionResult> Index(int gameId, int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            var sections = await _characterService.GetSectionsAsync(id, GetUserId());

            if (character == null || character.GameId != gameId || sections == null)
                return BadRequest(new { message = "Character Doesnt Exist" });

            var apiCharacter = new Character
            {
                Id = character.Id,
                GameId = character.GameId,
                Name = character.Name,
                UserCount = character.UserCount,
                Status = character.Status,
                Sections = sections
            };

            return new JsonResult(apiCharacter);
        }

        [AllowAnonymous]
        [Route("Icon/{id}")]
        [ResponseCache(Duration = 604800)]
        public async Task<IActionResult> CharacterIcon(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            if (character != null && character.IconImage != null)
                return File(character.IconImage.File, "image/png");
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [Authorize]
        [Route("AddCharacterLink")]
        public async Task<IActionResult> AddCharacterLink(AddRemoveCharacterLink vm)
        {
            var userId = GetUserId();
            await _entryService.AddReplaceCharacterLinkEntryAsync(vm.LinkEntryType, GetUserId(), vm.CharacterId, vm.LinkedCharacterId);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("RemoveCharacterLink")]
        public async Task<IActionResult> RemoveCharacterLink(AddRemoveCharacterLink vm)
        {
            var userId = GetUserId();
            await _entryService.RemoveCharacterLinkEntryAsync(vm.LinkEntryType, GetUserId(), vm.CharacterId, vm.LinkedCharacterId);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("AddTagEntry")]
        public async Task<IActionResult> AddTagEntry(AddTagEntry vm)
        {
            var userId = GetUserId();
            await _entryService.AddReplaceCharacterTagEntryAsync(vm.TagEntryType, GetUserId(), vm.CharacterId, vm.TagName);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("RemoveTagEntry")]
        public async Task<IActionResult> RemoveTagEntry(RemoveTagEntry vm)
        {
            var userId = GetUserId();
            await _entryService.RemoveCharacterTagEntryAsync(vm.TagEntryType, GetUserId(), vm.CharacterId, vm.TagId);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("AddValueEntry")]
        public async Task<IActionResult> AddValueEntry(AddRemoveValueEntry vm)
        {
            var userId = GetUserId();
            await _entryService.AddReplaceCharacterValueEntryAsync(vm.ValueEntryType, GetUserId(), vm.CharacterId, vm.Value);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("RemoveValueEntry")]
        public async Task<IActionResult> RemoveValueEntry(AddRemoveValueEntry vm)
        {
            var userId = GetUserId();
            await _entryService.RemoveCharacterValueEntryAsync(vm.ValueEntryType, GetUserId(), vm.CharacterId, vm.Value);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("AddStringEntry")]
        public async Task<IActionResult> AddStringEntry(AddStringEntry vm)
        {
            var userId = GetUserId();
            await _entryService.AddReplaceCharacterStringEntryAsync(vm.StringEntryType, GetUserId(), vm.CharacterId, vm.Text);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("RemoveStringEntry")]
        public async Task<IActionResult> RemoveStringEntry(RemoveStringEntry vm)
        {
            var userId = GetUserId();
            await _entryService.RemoveCharacterStringEntryAsync(vm.StringEntryType, GetUserId(), vm.CharacterId, vm.EntryId);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("AddStringEntryVote")]
        public async Task<IActionResult> AddStringEntryVote(AddRemoveStringEntryVote vm)
        {
            var userId = GetUserId();
            await _entryService.AddCharacterStringEntryVoteAsync(vm.StringEntryType, GetUserId(), vm.CharacterId, vm.EntryId);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [Authorize]
        [Route("RemoveStringEntryVote")]
        public async Task<IActionResult> RemoveStringEntryVote(AddRemoveStringEntryVote vm)
        {
            var userId = GetUserId();
            await _entryService.RemoveCharacterStringEntryVoteAsync(vm.StringEntryType, GetUserId(), vm.CharacterId, vm.EntryId);
            var sections = await _characterService.GetSectionsAsync(vm.CharacterId, userId);
            return new JsonResult(sections);
        }

        [AllowAnonymous]
        [Route("ReloadSections/{id}")]
        public async Task<IActionResult> ReloadSections(int id)
        {
            var userId = GetUserId();
            var sections = await _characterService.GetSectionsAsync(id, userId);
            return new JsonResult(sections);
        }
    }
}
