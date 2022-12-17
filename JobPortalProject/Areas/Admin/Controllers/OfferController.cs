using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalProject.Areas.Admin.Controllers
{
    public class OfferController : BaseController
    {
        private readonly IEmployerService employerService;
        private readonly IOfferService offerService;
        private readonly ICategoryService categoryService;

        public OfferController(IEmployerService _employerService, ICategoryService _categoryService, IOfferService _offerService)
        {
            this.employerService = _employerService;
            this.categoryService = _categoryService;
            this.offerService = _offerService;
        }

        public async Task<IActionResult> MyOffers()
        {
            int adminId = await employerService.GetEmployerId(User.Id());

            var model = await employerService.GetMyOffersAsync(adminId);

            return View(model);
        }

        public async Task<IActionResult> All()
        {
            var model = await categoryService.GetAllAsync();

            return View(model);
        }

        public async Task<IActionResult> OffersInCategory(int categoryId, int locationId)
        {
            if (categoryId == 0)
            {
                return BadRequest();
            }

            var model = await offerService.GetAllAsync(categoryId, locationId);

            return View(model);
        }
    }
}
