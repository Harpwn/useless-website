using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UselessCore.Enums.Entries;
using UselessCore.Enums.Entries.EntryEnums;
using UselessCore.Model;
using UselessCore.Model.Characters;
using UselessCore.Model.Entries;
using UselessCore.Model.Tags;
using UselessCore.Model.Users;
using UselessCore.Services.Tags;
using UselessCore.Services.Tags.Dtos;

namespace UselessCore.Services.Entries
{
    public class EntryService : Service, IEntryService
    {
        private readonly ITagService _tagService;

        public EntryService(UselessContext context, IMemoryCache cache, ITagService tagService, IMapper mapper) : base(context, cache, mapper)
        {
            _tagService = tagService;
        }

        public async Task<bool> AddReplaceCharacterLinkEntryAsync(CharacterLinkEntryType type, string userId, int characterId, int linkedCharacterId)
        {
            var character = await Context.Characters.FindAsync(characterId);
            var linkedCharacter = await Context.Characters.FindAsync(linkedCharacterId);
            var user = await Context.Users.FindAsync(userId);

            if (user == null || character == null || linkedCharacter == null || (type != CharacterLinkEntryType.SimilarInGenre && character.Game != linkedCharacter.Game))
                return false;

            var linkEntry = character.LinkEntries.FirstOrDefault(e => e.Type == type && e.LinkedCharacter.Id == linkedCharacter.Id && e.User == user);
            if (linkEntry != null)
                character.LinkEntries.Remove(linkEntry);

            character.LinkEntries.Add(new CharacterLinkEntry
            {
                Character = character,
                LinkedCharacter = linkedCharacter,
                User = user,
                Type = type
            });
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddReplaceCharacterTagEntryAsync(CharacterTagEntryType type, string userId, int characterId, string tagText)
        {
            var character = await Context.Characters.FindAsync(characterId);
            var tag = await _tagService.GetOrCreateTagAsync(tagText);
            var user = await Context.Users.FindAsync(userId);

            if (user == null || character == null || tag == null)
                return false;

            var mainTag = character.TagEntries.FirstOrDefault(e => e.Type == type && e.LinkedTag.Id == tag.Id && e.User == user);
            if (mainTag != null)
                character.TagEntries.Remove(mainTag);

            character.TagEntries.Add(new CharacterTagEntry
            {
                Character = character,
                LinkedTag = tag,
                User = user,
                Type = type
            });
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddReplaceCharacterValueEntryAsync(CharacterValueEntryType type, string userId, int characterId, int valueValue)
        {
            var character = await Context.Characters.FindAsync(characterId);
            var user = await Context.Users.FindAsync(userId);

            if (user == null || character == null)
                return false;

            var enumEntry = character.ValueEntries.FirstOrDefault(e => e.Type == type && e.User == user);
            if (enumEntry != null)
                character.ValueEntries.Remove(enumEntry);
            
            character.ValueEntries.Add(new CharacterValueEntry
            {
                Character = character,
                Value = valueValue,
                User = user,
                Type = type
            });
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddReplaceCharacterStringEntryAsync(CharacterStringEntryType type, string userId, int characterId, string text)
        {
            var character = await Context.Characters.FindAsync(characterId);
            var user = await Context.Users.FindAsync(userId);

            if (user == null || character == null)
                return false;

            var value = character.StringEntries.FirstOrDefault(e => e.Type == type && e.Text == text && e.User == user);
            if (value != null)
                character.StringEntries.Remove(value);
            
            character.StringEntries.Add(new CharacterStringEntry
            {
                Character = character,
                Text = text,
                User = user,
                Type = type
            });
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddCharacterStringEntryVoteAsync(CharacterStringEntryType type, string userId, int characterId, int entryId)
        {
            var character = await Context.Characters.FindAsync(characterId);
            var user = await Context.Users.FindAsync(userId);
            var entry = character?.StringEntries.SingleOrDefault(t => t.Type == type && t.Id == entryId);
            var existingVote = entry?.Votes.SingleOrDefault(v => v.User.Id == userId);

            if (user == null || character == null || entry == null || existingVote != null)
                return false;

            entry.Votes.Add(new EntryVote { User = user });
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCharacterLinkEntryAsync(CharacterLinkEntryType type, string userId, int characterId, int linkedCharacterId)
        {
            var user = await Context.Users.FindAsync(userId);
            var character = await Context.Characters.FindAsync(characterId);
            var linkedCharacter = await Context.Characters.FindAsync(linkedCharacterId);

            if (user == null || character == null || linkedCharacter == null)
                return false;

            var linkEntry = character.LinkEntries.FirstOrDefault(e => e.Type == type & e.LinkedCharacter.Id == linkedCharacter.Id && e.User == user);

            if (linkEntry == null)
                return false;

            character.LinkEntries.Remove(linkEntry);
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCharacterTagEntryAsync(CharacterTagEntryType type, string userId, int characterId, int tagId)
        {
            var user = await Context.Users.FindAsync(userId);
            var character = await Context.Characters.FindAsync(characterId);
            var tag = await Context.Tags.FindAsync(tagId);

            if (user == null || character == null || tag == null)
                return false;

            var mainTag = character.TagEntries.FirstOrDefault(e => e.Type == type && e.LinkedTag.Id == tag.Id && e.User == user);
            if (mainTag == null)
                return false;

            character.TagEntries.Remove(mainTag);
            Context.Update(character);
            await Context.SaveChangesAsync();
            await _tagService.TryDeleteAsync(tag.Id);
            return true;
        }

        public async Task<bool> RemoveCharacterValueEntryAsync(CharacterValueEntryType type, string userId, int characterId, int enumVal)
        {
            var user = await Context.Users.FindAsync(userId);
            var character = await Context.Characters.FindAsync(characterId);

            if (user == null || character == null)
                return false;

            var value = character.ValueEntries.FirstOrDefault(e => e.Type == type && e.Value == enumVal && e.User == user);
            if (value == null)
                return false;

            character.ValueEntries.Remove(value);
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCharacterStringEntryAsync(CharacterStringEntryType type, string userId, int characterId, int entryId)
        {
            var user = await Context.Users.FindAsync(userId);
            var character = await Context.Characters.FindAsync(characterId);

            if (user == null || character == null)
                return false;

            var value = character.StringEntries.FirstOrDefault(e => e.Type == type && e.Id == entryId && e.User == user);
            if (value == null)
                return false;

            value.Votes.Clear();
            character.StringEntries.Remove(value);
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCharacterStringEntryVoteAsync(CharacterStringEntryType type, string userId, int characterId, int entryId)
        {
            var character = await Context.Characters.FindAsync(characterId);
            var entry = character?.StringEntries.SingleOrDefault(t => t.Type == type && t.Id == entryId);
            var vote = entry?.Votes.SingleOrDefault(v => v.User.Id == userId);

            if (character == null || entry == null || vote == null)
                return false;
            
            entry.Votes.Remove(vote);
            Context.Update(character);
            await Context.SaveChangesAsync();
            return true;
        }

    }
}
