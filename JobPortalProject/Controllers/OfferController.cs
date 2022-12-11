using JobPortalProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using JobPortalProject.Core.Infrastructure;

namespace JobPortalProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;
        private readonly IEmployerService employerService;

        public OfferController(IOfferService _offerService, IEmployerService _employerService)
        {
            this.offerService = _offerService;
            this.employerService = _employerService;
        }

        public async Task<IActionResult> ShowAllOffersInCategory(int categoryId, int locationId)
        {
            var model = await offerService.GetAllAsync(categoryId, locationId);

            return View(model);
        }

        public async Task<IActionResult> ShowSingleOffer(int offerId)
        {
            var model = await offerService.GetOfferAsync(offerId);

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> ApplyForOffer(int offerId)
        {
            var employeeId = User.Id();

            if (await employerService.ExistsById(employeeId))
            {
                return BadRequest("Employer cannot apply for offer.");
            }

            if (await offerService.IsApplied(offerId, employeeId))
            {
                return View("AlreadyApplied");
            }

            await offerService.ApplyForOfferAsync(offerId, employeeId);

            return View("ThankYouForApplying");
        }

        public async Task<IActionResult> Details(int offerId)
        {
            if (await offerService.Exists(offerId) == false)
            {
                return View();
            }

            if (await offerService.HasEmployerWithIdAsync(offerId, User.Id()) == false)
            {
                return Unauthorized();
            }

            return RedirectToAction("ShowSingleOffer", "Offer", new { offerId = offerId });
        }
    }
}
