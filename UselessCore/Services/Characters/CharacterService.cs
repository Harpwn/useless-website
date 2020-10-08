using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Constants;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Enums.Entries.EntryEnums;
using UselessCore.Model;
using UselessCore.Model.Characters;
using UselessCore.Model.Images;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries;
using UselessCore.Services.Games;

namespace UselessCore.Services.Characters
{
    public class CharacterService : Service, ICharacterService
    {
        private ISectionBuilderFactory _sectionBuilderFactory;

        public CharacterService(UselessContext context, IMemoryCache cache, IMapper mapper, ISectionBuilderFactory sectionBuilderFactory) : base(context, cache, mapper)
        {
            _sectionBuilderFactory = sectionBuilderFactory;
        }

        public async Task<int> AddAsync(CharacterDto characterDto)
        {
            var character = new Character
            {
                Name = characterDto.Name,
                GameId = characterDto.GameId,
                Status = characterDto.Status,
            };

            if (characterDto.IconImage != null && characterDto.IconImage.File != null)
                character.IconImage = new Image { File = characterDto.IconImage.File };


            Context.Add(character);
            await Context.SaveChangesAsync();
            return character.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var character = await Context.Characters.FindAsync(id);
            if (character != null)
            {
                if (character.IconImage != null)
                    Context.Remove(character.IconImage);

                Context.Remove(character);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EditAsync(CharacterDto character)
        {
            var existingCharacter = await Context.Characters.FindAsync(character.Id);
            if (existingCharacter != null)
            {
                existingCharacter.Name = character.Name;
                existingCharacter.Status = character.Status;
                existingCharacter.LastModified = DateTime.UtcNow;

                if(existingCharacter.IconImage != null)
                {
                    existingCharacter.IconImage.File = character.IconImage?.File;
                    existingCharacter.IconImage.LastModified = character.IconImage?.LastModified ?? existingCharacter.IconImage.LastModified;
                }
                else
                {
                    if (character.IconImage != null && character.IconImage.File != null)
                        existingCharacter.IconImage = new Image { File = character.IconImage.File };
                }
                
                Context.Update(existingCharacter);
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BaseCharacterDto>> GetAllAsync(EntityStatus? status = null)
        {
            return await Mapper.ProjectTo<BaseCharacterDto>(
                Context.Characters
                .Where(c => !status.HasValue || c.Status == status))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<BaseCharacterDto>> GetAllForGameAsync(int gameId, EntityStatus? status = null)
        {
            var game = await Context.Games.FindAsync(gameId);
            if (game != null)
            {
                return await Mapper.ProjectTo<BaseCharacterDto>(
                    Context.Characters
                    .Where(c => c.GameId == gameId)
                    .Where(c => !status.HasValue || c.Status == status.Value))
                    .OrderBy(c => c.Name)
                    .ToListAsync();
            }
            return null;
        }

        public async Task<CharacterDto> GetByIdAsync(int id)
        {
            var character = await Context.Characters.FindAsync(id);
            return character != null ? Mapper.Map<CharacterDto>(character) : null;
        }

        public async Task<List<ISection>> GetSectionsAsync(int id, string userId = null)
        {
            var character = await Context.Characters.FindAsync(id);

            if (character == null)
                return null;

            var characters = await Context.Characters
                .Where(c => c.Id != id).OrderBy(c => c.Name).Select(c => new BaseCharacterDto { Id = c.Id, Name = c.Name, GameId = c.GameId }).ToListAsync();

            var builder = _sectionBuilderFactory.GetSectionBuilder(character, characters, userId);

            builder.BuildMainTagSection();
            builder.BuildTierSection();
            builder.BuildTipsSection();
            builder.BuildSimilarInGameSection();
            builder.BuildSimilarInGenreSection();
            builder.BuildCounteredBySection();
            builder.BuildStrongAgainstSection();
            builder.BuildSynergizesWithSection();

            return builder.GetResult();
        }
    }
}
