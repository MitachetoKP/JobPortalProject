using JobPortalProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace JobPortalProject.Controllers
{
    public class OfferController : Controller
    {
        private IOfferService offerService;

        public OfferController(IOfferService _offerService)
        {
            this.offerService = _offerService;
        }

        public async Task<IActionResult> ShowAllOffersInCategory(int categoryId)
        {
            var model = await offerService.GetAllAsync(categoryId);

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
            var employeeId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (await offerService.IsApplied(offerId, employeeId))
            {
                return Ok("Already applied!");
            }

            await offerService.ApplyForOfferAsync(offerId, employeeId);

            return RedirectToAction("Index", "Home");
        }
    }
}
