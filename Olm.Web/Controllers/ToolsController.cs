using Microsoft.AspNetCore.Mvc;

namespace Olm.Web.Controllers
{
    public class ToolsController : BaseController
    {
        public IActionResult GennerateAdslink()
        {
            return View();
        }
    }
}