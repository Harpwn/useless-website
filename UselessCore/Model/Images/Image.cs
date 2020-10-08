using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UselessCore.Model.Characters;
using UselessCore.Model.Games;

namespace UselessCore.Model.Images
{
    [Table("Images")]
    public class Image : Entity
    {
        [Required]
        [MaxLength(5000000)]
        public virtual byte[] File { get; set; }

    }
}
