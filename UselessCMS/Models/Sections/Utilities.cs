using System.Linq;
using UselessCMS.Models.Characters;
using UselessCore.Enums;
using UselessCore.Services.Entries;
using UselessCore.Services.Entries.Dtos;

namespace UselessCMS.Models.Sections
{
    public static class Utilities
    {
        public static ISectionViewModel Translate(this ISection dto)
        {
            switch(dto.Type)
            {
                case SectionType.Character:
                    var linkDto = dto as CharacterLinkSectionDto;

                    return new CharacterLinkSectionViewModel
                    {
                        CharacterId = linkDto.CharacterId,
                        Title = linkDto.Title,
                        LinkType = linkDto.LinkEntryType,
                        Links = linkDto.Links.Select(e => e.Translate()),
                        AvaliableCharacters = linkDto.AvaliableCharacters.Select(ac => new CharacterSelectionViewModel { Id = ac.ID, Name = ac.Name })
                    };
                case SectionType.Tag:
                    var tagDto = dto as CharacterTagSectionDto;

                    return new CharacterTagSectionViewModel
                    {
                        CharacterId = tagDto.CharacterId,
                        Title = tagDto.Title,
                        TagEntryType = tagDto.TagEntryType,
                        Tags = tagDto.Tags.Select(t => t.Translate())
                    };
                case SectionType.Value:
                    var valueDto = dto as CharacterValueSectionDto;

                    return new CharacterValueSectionViewModel
                    {
                        CharacterId = valueDto.CharacterId,
                        Title = valueDto.Title,
                        ValueEntryType = valueDto.ValueEntryType,
                        Values = valueDto.Values.Select(e => e.Translate()),
                    };
                case SectionType.String:
                    var stringDto = dto as CharacterStringSectionDto;

                    return new CharacterStringSectionViewModel
                    {
                        CharacterId = stringDto.CharacterId,
                        Title = stringDto.Title,
                        StringEntryType = stringDto.StringEntryType,
                        Values = stringDto.Values.Select(v => v.Translate())
                    };
                default:
                    return null;
            }
        }

        public static CharacterLinkViewModel Translate(this CharacterLinkDto dto)
        {
            return new CharacterLinkViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                LinkCount = dto.LinkCount,
                UserHasSelected = dto.UserSelected
            };
        }

        public static CharacterTagViewModel Translate(this CharacterTagDto dto)
        {
            return new CharacterTagViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                Type = dto.Type,
                UserHasSelected = dto.UserSelected,
                TagCount = dto.TagCount
            };
        }

        public static CharacterValueViewModel Translate(this CharacterValueDto dto)
        {
            return new CharacterValueViewModel
            {
                ID = dto.ID,
                Name = dto.Name,
                ValueCount = dto.ValueCount,
                UserHasSelected = dto.UserSelected
            };
        }

        public static CharacterStringViewModel Translate(this CharacterStringDto dto)
        {
            return new CharacterStringViewModel
            {
                ID = dto.ID,
                Text = dto.Text,
                ValueCount = dto.ValueCount,
                CreatedByUserName = dto.CreatorDisplayName,
                UserCreated = dto.UserCreated,
                UserSelected = dto.UserSelected
            };
        }
    }
}
