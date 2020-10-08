using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UselessCore.Model;
using UselessCore.Model.Games;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UselessCore.Enums;
using UselessCore.Model.Images;
using AutoMapper;
using UselessCore.Services.Games.Dtos;

namespace UselessCore.Services.Games
{
    public class GameService : Service, IGameService
    {
        public GameService(UselessContext context, IMemoryCache cache, IMapper mapper) : base(context, cache, mapper)
        {

        }

        public async Task<int> AddAsync(GameDto game)
        {
            var newGame = new Game
            {
                Name = game.Name,
                Status = game.Status,
                HasSite = game.HasSite,
                GameKey = game.GameKey,
                LinkEntryTypes = game.LinkEntryTypes,
                StringEntryTypes = game.StringEntryTypes,
                TagEntryTypes = game.TagEntryTypes,
                ValueEntryTypes = game.ValueEntryTypes
            };

            if (game.GameLogo != null && game.GameLogo.File != null)
                newGame.GameLogo = new Image { File = game.GameLogo.File };

            Context.Games.Add(newGame);

            await Context.SaveChangesAsync();
            return newGame.Id;
        }

        public async Task<bool> EditAsync(GameDto gameDto)
        {
            var game = await Context.Games.FindAsync(gameDto.Id);
            if (game != null)
            {
                game.Name = gameDto.Name;
                game.LastModified = DateTime.UtcNow;
                game.Status = gameDto.Status;
                game.HasSite = gameDto.HasSite;
                game.GameKey = gameDto.GameKey;
                game.StringEntryTypes = gameDto.StringEntryTypes;
                game.ValueEntryTypes = gameDto.ValueEntryTypes;
                game.TagEntryTypes = gameDto.TagEntryTypes;
                game.LinkEntryTypes = gameDto.LinkEntryTypes;

                if(game.GameLogo != null)
                {
                    game.GameLogo.File = gameDto.GameLogo?.File ?? null;
                    game.GameLogo.LastModified = gameDto.GameLogo?.LastModified ?? game.GameLogo.LastModified;
                }
                else
                {
                    if (game.GameLogo != null && game.GameLogo.File != null)
                        game.GameLogo = new Image { File = gameDto.GameLogo.File };
                }

                Context.Update(game);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await Context.Games.FindAsync(id);

            if (game != null && !game.Characters.Any())
            {

                if (game.GameLogo != null)
                    Context.Remove(game.GameLogo);

                Context.Remove(game);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync(EntityStatus? status = null)
        {
            return await Mapper.ProjectTo<GameDto>(Context.Games
                    .Where(g => !status.HasValue || g.Status == status.Value))
                .ToListAsync();
        }

        public async Task<Image> GetLogoAsync(int id)
        {
            var game = await Context.Games.FindAsync(id);

            if (game == null)
                return null;

            return game.GameLogo;
        }

        public async Task<GameDto> GetByIdAsync(int id)
        {
            var game = await Context.Games.FindAsync(id);

            if (game != null)
                return Mapper.Map<GameDto>(game);
            
            return null;
        }

    }
}
