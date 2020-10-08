using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UselessCore.Constants;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Enums.Entries.EntryEnums;
using UselessCore.Model.Characters;
using UselessCore.Services.Characters.Dtos;
using UselessCore.Services.Entries.Dtos;

namespace UselessCore.Services.Entries
{
    public class SectionBuilder : ISectionBuilder
    {
        private List<ISection> _sections = new List<ISection>();
        private readonly Character _character;
        private readonly List<BaseCharacterDto> _characters;
        private string _userId;

        public SectionBuilder(Character character, List<BaseCharacterDto> characters, string userId = null)
        {
            _character = character;
            _characters = characters;
            _userId = userId;
        }

        public List<ISection> GetResult()
        {
            return _sections;
        }

        public void BuildMainTagSection()
        {
            if(_character.Game.TagEntryTypes.Contains(CharacterTagEntryType.Main))
                _sections.Add(BuildTagSection(_character, CharacterTagEntryType.Main, _userId));
        }

        public void BuildTierSection()
        {
            if(_character.Game.ValueEntryTypes.Contains(CharacterValueEntryType.Tier))
                _sections.Add(BuildValueSection(_character, CharacterValueEntryType.Tier, _userId));
        }

        public void BuildTipsSection()
        {
            if(_character.Game.StringEntryTypes.Contains(CharacterStringEntryType.Tips))
                _sections.Add(BuildStringSection(_character, CharacterStringEntryType.Tips, _userId));
        }

        public void BuildSimilarInGameSection()
        {
            if(_character.Game.LinkEntryTypes.Contains(CharacterLinkEntryType.SimilarInGame))
                _sections.Add(BuilderCharacterLinkSection(_character, CharacterLinkEntryType.SimilarInGame, _characters, _userId));
        }

        public void BuildSimilarInGenreSection()
        {
            if (_character.Game.LinkEntryTypes.Contains(CharacterLinkEntryType.SimilarInGenre))
                _sections.Add(BuilderCharacterLinkSection(_character, CharacterLinkEntryType.SimilarInGenre, _characters, _userId));
        }

        public void BuildCounteredBySection()
        {
            if (_character.Game.LinkEntryTypes.Contains(CharacterLinkEntryType.CounteredBy))
                _sections.Add(BuilderCharacterLinkSection(_character, CharacterLinkEntryType.CounteredBy, _characters, _userId));
        }

        public void BuildStrongAgainstSection()
        {
            if (_character.Game.LinkEntryTypes.Contains(CharacterLinkEntryType.StrongAgainst))
                _sections.Add(BuilderCharacterLinkSection(_character, CharacterLinkEntryType.StrongAgainst, _characters, _userId));
        }

        public void BuildSynergizesWithSection()
        {
            if(_character.Game.LinkEntryTypes.Contains(CharacterLinkEntryType.SynergizesWith))
                _sections.Add(BuilderCharacterLinkSection(_character, CharacterLinkEntryType.SynergizesWith, _characters, _userId));
        }

        private CharacterTagSectionDto BuildTagSection(Character character, CharacterTagEntryType type, string userId)
        {
            var sectionDto = new CharacterTagSectionDto
            {
                CharacterId = character.Id,
                GameId = character.GameId,
                TagEntryType = type,
                Tags = character.TagEntries
                    .Where(t => t.Type == type)
                    .GroupBy(s => s.LinkedTag)
                    .Select(ge => new CharacterTagDto
                    {
                        ID = ge.Key.Id,
                        Name = ge.Key.Name,
                        Type = ge.Key.Type,
                        Timestamp = ((DateTimeOffset)ge.Key.CreatedDate).ToUnixTimeSeconds(),
                        TagCount = ge.Count(),
                        UserSelected = userId != null && ge.Any(s => s.User.Id == userId)
                    })
            };

            switch (type)
            {
                case CharacterTagEntryType.Main:
                    sectionDto.Title = "Tags";
                    sectionDto.Description = "<b>Main Tags</b><br/>In this section we add tags related to playstyle, mechanics or theme.<br/><br/>" + SectionDescriptionConstants.TagEntrySection;
                    break;
                default:
                    throw new NotImplementedException();
            }


            return sectionDto;
        }

        private CharacterLinkSectionDto BuilderCharacterLinkSection(Character character, CharacterLinkEntryType type, IEnumerable<BaseCharacterDto> characters, string userId)
        {
            var linkEntries = character.LinkEntries
                    .Where(e => e.Type == type)
                    .GroupBy(s => s.LinkedCharacter)
                    .Select(ge => new CharacterLinkDto
                    {
                        ID = ge.Key.Id,
                        GameId = ge.Key.GameId,
                        GameName = ge.Key.Game.Name,
                        Name = ge.Key.Name,
                        LinkCount = ge.Count(),
                        UserSelected = userId != null && ge.Any(s => s.User.Id == userId)
                    });

            characters = type == CharacterLinkEntryType.SimilarInGenre ? characters.Where(c => c.GameId != character.GameId) : characters.Where(c => c.GameId == character.GameId);

            var sectionDto = new CharacterLinkSectionDto
            {
                CharacterId = character.Id,
                GameId = character.GameId,
                LinkEntryType = type,
                Links = linkEntries,
                AvaliableCharacters = characters.Select(c => new CharacterLinkDto
                {
                    ID = c.Id,
                    GameId = c.GameId,
                    GameName = c.GameName,
                    Name = c.Name,
                    LinkCount = linkEntries.SingleOrDefault(l => l.ID == c.Id)?.LinkCount ?? 0,
                    UserSelected = linkEntries.SingleOrDefault(l => l.ID == c.Id)?.UserSelected ?? false
                })
            };

            switch (type)
            {
                case CharacterLinkEntryType.SimilarInGame:
                    sectionDto.Title = "Similar In Game";
                    sectionDto.Description = "<b>Similar In Game</b><br/>In this section we link to similar characters based on playstyle/mechanics or theme.<br/><br/>" + SectionDescriptionConstants.CharacterLinkSection;
                    break;
                case CharacterLinkEntryType.SimilarInGenre:
                    sectionDto.Title = "Similar In Genre";
                    sectionDto.Description = "<b>Similar In Genre</b><br/>In this section we link to similar characters based on playstyle/mechanics or theme. Options for this section are based on the useless network collection of games and characters which should be updated regularly.<br/><br/>" + SectionDescriptionConstants.CharacterLinkSection;
                    break;
                case CharacterLinkEntryType.CounteredBy:
                    sectionDto.Title = "Countered By";
                    sectionDto.Description = $"<b>Countered By</b><br/>In this section we link to charaters that counter {character.Name}.<br/><br/>" + SectionDescriptionConstants.CharacterLinkSection;
                    break;
                case CharacterLinkEntryType.StrongAgainst:
                    sectionDto.Title = "Strong Against";
                    sectionDto.Description = $"<b>Strong Against</b><br/>In this section we link to charaters that are strong against {character.Name}.<br/><br/>" + SectionDescriptionConstants.CharacterLinkSection;
                    break;
                case CharacterLinkEntryType.SynergizesWith:
                    sectionDto.Title = "Synergizes With";
                    sectionDto.Description = $"<b>Synergizes With</b><br/>In this section we link to charaters that synergize well with {character.Name}.<br/><br/>" + SectionDescriptionConstants.CharacterLinkSection;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return sectionDto;
        }

        private CharacterValueSectionDto BuildValueSection(Character character, CharacterValueEntryType type, string userId)
        {

            var characterValues = character.ValueEntries
                .Where(v => v.Type == type)
                .GroupBy(s => s.Value)
                .Select(ge => new CharacterValueDto
                {
                    ID = ge.Key,
                    Name = GetValueName(ge.Key, type),
                    ValueCount = ge.Count(),
                    UserSelected = userId != null && ge.Any(s => s.User.Id == userId)
                }).OrderBy(ge => ge.ValueCount);


            var sectionDto = new CharacterValueSectionDto
            {
                CharacterId = character.Id,
                GameId = character.GameId,
                ValueEntryType = type,
            };

            switch (type)
            {
                case CharacterValueEntryType.Tier:
                    sectionDto.Title = "Tier List";
                    sectionDto.Description = $"<b>Tier List</b><br/>In this section we select one of the tiers to indicate the overall strength of {character.Name}.<br/><br/>" + SectionDescriptionConstants.EnumEntrySection;
                    sectionDto.Values = characterValues.Union(CharacterTier.A.GetListForEnum().Where(e => !characterValues.Select(ce => ce.ID).Contains(e.ID))).OrderBy(ce => ce.ID);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return sectionDto;
        }

        private string GetValueName(int value, CharacterValueEntryType type)
        {
            switch (type)
            {
                case CharacterValueEntryType.Tier:
                    return ((CharacterTier)value).GetDisplayName();
                default:
                    throw new NotImplementedException();
            }
        }

        private CharacterStringSectionDto BuildStringSection(Character character, CharacterStringEntryType type, string userID)
        {

            var characterStrings = character.StringEntries
                .Where(s => s.Type == type)
                .Select(ge =>
                    new CharacterStringDto
                    {
                        ID = ge.Id,
                        Text = ge.Text,
                        CreatorDisplayName = string.IsNullOrEmpty(ge.User.DisplayName) ? "Anonymous" : ge.User.DisplayName,
                        CreatorAvatarIcon = ge.User.AvatarIconId,
                        UserCreated = ge.User.Id == userID,
                        UserSelected = ge.Votes.Any(v => v.User.Id == userID),
                        ValueCount = ge.Votes.Count()
                    })
                .OrderBy(ge => ge.ValueCount);


            var sectionDto = new CharacterStringSectionDto
            {
                CharacterId = character.Id,
                GameId = character.GameId,
                StringEntryType = type,
                Values = characterStrings
            };

            switch (type)
            {
                case CharacterStringEntryType.Tips:
                    sectionDto.Title = "Tips & Tricks";
                    sectionDto.Description = $"<b>Tips & Tricks</b><br/>In this section we list tips and tricks for {character.Name}.<br/><br/>" + SectionDescriptionConstants.StringEntrySection;
                    break;
                default:
                    throw new NotImplementedException();
            }


            return sectionDto;
        }
        
    }
}
