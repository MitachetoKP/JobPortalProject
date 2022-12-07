using Microsoft.AspNetCore.Mvc;

namespace JobPortalProject.Areas.Employer.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
