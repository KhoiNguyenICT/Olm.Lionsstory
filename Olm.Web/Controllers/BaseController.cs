using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Olm.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}