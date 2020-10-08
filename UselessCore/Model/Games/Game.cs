using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UselessCore.Enums;
using UselessCore.Enums.Entries;
using UselessCore.Model.Characters;
using UselessCore.Model.Images;
using static UselessCore.Enums.EnumExtensions;

namespace UselessCore.Model.Games
{
    public class Game : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public EntityStatus Status { get; set; }

        public virtual Image GameLogo { get; set; }

        public bool HasSite { get; set; }
        public string GameKey { get; set; }

        public virtual ICollection<Character> Characters { get; set; } = new List<Character>();


        public string ValueEntryTypesCsv { get; set; }

        [NotMapped]
        public IEnumerable<CharacterValueEntryType> ValueEntryTypes
        {
            get
            {
                return EnumsFromCSV<CharacterValueEntryType>(ValueEntryTypesCsv);
            }
            set
            {
                ValueEntryTypesCsv = CSVFromEnums(value);
            }
        }

        public string StringEntryTypesCsv { get; set; }

        [NotMapped]
        public IEnumerable<CharacterStringEntryType> StringEntryTypes
        {
            get
            {
                return EnumsFromCSV<CharacterStringEntryType>(StringEntryTypesCsv);
            }
            set
            {
                StringEntryTypesCsv = CSVFromEnums(value);
            }
        }

        public string TagEntryTypesCsv { get; set; }

        [NotMapped]
        public IEnumerable<CharacterTagEntryType> TagEntryTypes
        {
            get
            {
                return EnumsFromCSV<CharacterTagEntryType>(TagEntryTypesCsv);
            }
            set
            {
                TagEntryTypesCsv = CSVFromEnums(value);
            }
        }

        public string LinkEntryTypesCsv { get; set; }

        [NotMapped]
        public IEnumerable<CharacterLinkEntryType> LinkEntryTypes
        {
            get
            {
                return EnumsFromCSV<CharacterLinkEntryType>(LinkEntryTypesCsv);
            }
            set
            {
                LinkEntryTypesCsv = CSVFromEnums(value);
            }
        }

    }
}
