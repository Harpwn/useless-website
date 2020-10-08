using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UselessCMS.Models.Characters
{
    public class BaseCharacterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
    }
}
