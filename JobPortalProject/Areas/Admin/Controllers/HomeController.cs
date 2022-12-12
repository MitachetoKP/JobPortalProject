using Microsoft.AspNetCore.Mvc;

namespace JobPortalProject.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
