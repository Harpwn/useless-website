using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UselessAPI.Model.Users
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? AvatarIconId { get; set; } 
        public string DisplayName { get; set; }
    }
}
