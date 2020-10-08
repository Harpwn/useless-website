using Microsoft.AspNetCore.Mvc;

namespace UselessAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected string GetUserId()
        {
            return HttpContext.User.Identity.Name;
        }
    }
}
