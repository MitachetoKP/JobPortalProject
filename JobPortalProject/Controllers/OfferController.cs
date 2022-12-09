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

        public OfferController(IOfferService _offerService)
        {
            this.offerService = _offerService;
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

            if (await offerService.IsApplied(offerId, employeeId))
            {
                return View("AlreadyApplied");
            }

            await offerService.ApplyForOfferAsync(offerId, employeeId);

            return View("ThankYouForApplying");
        }
    }
}
