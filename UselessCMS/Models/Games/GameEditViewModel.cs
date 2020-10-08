using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Web.Validation;

namespace UselessCMS.Models.Games
{
    public class GameEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool HasSite { get; set; }

        public string GameKey { get; set; }

        [Required]
        public EntityStatus Status { get; set; }

        public bool HasLogo { get; set; }

        public IEnumerable<CharacterValueEntryType> ValueEntryTypes { get; set; } = new List<CharacterValueEntryType>();
        public IEnumerable<CharacterStringEntryType> StringEntryTypes { get; set; } = new List<CharacterStringEntryType>();
        public IEnumerable<CharacterLinkEntryType> LinkEntryTypes { get; set; } = new List<CharacterLinkEntryType>();
        public IEnumerable<CharacterTagEntryType> TagEntryTypes { get; set; } = new List<CharacterTagEntryType>();

        [Display(Name="New Logo")]
        [ValidateFile(ErrorMessage = "Please Select an Image of Type PNG/JPEG smaller than 1MB")]
        public IFormFile GameLogo { get; set; }
    }
}
