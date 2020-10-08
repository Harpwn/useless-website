using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UselessCore.Enums.Entries;
using UselessCore.Model.Characters;
using UselessCore.Model.Users;

namespace UselessCore.Model.Entries
{
    public class CharacterValueEntry : Entity
    {
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Character Character { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public CharacterValueEntryType Type { get; set; }

        public virtual ICollection<EntryVote> Votes { get; set; } = new List<EntryVote>();
    }
}
