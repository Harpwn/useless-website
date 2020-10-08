using System.ComponentModel.DataAnnotations;
using UselessCore.Model.Users;

namespace UselessCore.Model.Entries
{
    public class EntryVote : Entity
    {
        [Required]
        public virtual User User { get; set; }
    }
}
