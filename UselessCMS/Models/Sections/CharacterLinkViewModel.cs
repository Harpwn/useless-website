using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UselessCMS.Models.Sections
{
    public class CharacterLinkViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LinkCount { get; set; }
        public bool UserHasSelected { get; set; }
    }
}
