using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UselessCore.Enums;

namespace UselessCMS.Models.Home
{
    public class HomePageViewModel : MasterViewModel
    {
        public RoleType Role { get; set; }
    }
}
