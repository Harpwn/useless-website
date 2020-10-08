using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UselessCore.Enums.Entries;
using UselessCore.Model.Characters;
using UselessCore.Model.Users;

namespace UselessCore.Model.Entries
{
    public class CharacterStringEntry : Entity
    {
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Character Character { get; set; }

        [Required]
        public virtual string Text { get; set; }

        [Required]
        public CharacterStringEntryType Type { get; set; }

        public virtual ICollection<EntryVote> Votes { get; set; } = new List<EntryVote>();
    }
}
