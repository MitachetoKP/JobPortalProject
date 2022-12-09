using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobPortalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;

        public HomeController(
            ILogger<HomeController> logger,
            ICategoryService _categoryService)
        {
            _logger = logger;
            categoryService = _categoryService;
        }

        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "Home", new { area = "Admin" });
            //}

            var model = await categoryService.GetAllAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}