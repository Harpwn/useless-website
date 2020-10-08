using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UselessCore.Enums;

namespace UselessCore.Model
{
    public abstract class Entity
    {
        public Entity()
        {
            CreatedDate = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModified { get; set; }
    }
}
