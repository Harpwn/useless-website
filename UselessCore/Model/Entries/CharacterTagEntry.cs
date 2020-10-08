using System.ComponentModel.DataAnnotations;
using UselessCore.Model.Characters;
using UselessCore.Model.Users;
using UselessCore.Model.Tags;
using UselessCore.Enums.Entries;
using System.Collections.Generic;

namespace UselessCore.Model.Entries
{
    public class CharacterTagEntry : Entity
    {
        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Character Character { get; set; }

        [Required]
        public virtual Tag LinkedTag { get; set; }

        [Required]
        public CharacterTagEntryType Type { get; set; }

        public virtual ICollection<EntryVote> Votes { get; set; } = new List<EntryVote>();
    }
}
