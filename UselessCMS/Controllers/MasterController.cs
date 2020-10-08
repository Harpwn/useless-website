using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UselessCore.Web.Auth;

namespace UselessCMS.Controllers
{
    [Authorize(Roles = RoleHelpers.Admin)]
    public abstract class MasterController : Controller
    {
        internal IMapper _mapper;
        public MasterController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
