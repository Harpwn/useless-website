using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UselessCore.Enums;
using UselessCore.Model.Entries;
using UselessCore.Model.Games;
using UselessCore.Model.Images;

namespace UselessCore.Model.Characters
{
    public class Character : Entity    
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual Image IconImage { get; set; }
        
        [Required]
        public virtual Game Game { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public EntityStatus Status { get; set; }

        public virtual ICollection<CharacterTagEntry> TagEntries { get; set; } = new List<CharacterTagEntry>();
        public virtual ICollection<CharacterLinkEntry> LinkEntries { get; set; } = new List<CharacterLinkEntry>();
        public virtual ICollection<CharacterValueEntry> ValueEntries { get; set; } = new List<CharacterValueEntry>();
        public virtual ICollection<CharacterStringEntry> StringEntries { get; set; } = new List<CharacterStringEntry>();
    }
}
