using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UselessCore.Enums;
using UselessCore.Web.Validation;

namespace UselessCMS.Models.Characters
{
    public class CharacterEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int GameId { get; set; }

        public bool HasIcon { get; set; }

        [Required]
        public EntityStatus Status { get; set; }

        [Display(Name = "Character Icon Image")]
        [ValidateFile(ErrorMessage = "Please Select an Image of Type PNG/JPEG smaller than 1MB")]
        public IFormFile IconImage { get; set; }
    }
}
