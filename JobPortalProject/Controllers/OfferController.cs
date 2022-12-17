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
            if (categoryId == 0)
            {
                return BadRequest();
            }

            var model = await offerService.GetAllAsync(categoryId, locationId);
                
            return View(model);
        }

        public async Task<IActionResult> ShowSingleOffer(int offerId)
        {
            if (await offerService.Exists(offerId) == false)
            {
                return BadRequest();
            }

            if (await offerService.HasEmployerWithIdAsync(offerId, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await offerService.GetOfferAsync(offerId);

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> ApplyForOffer(int offerId)
        {
            var employeeId = User.Id();

            if (await offerService.Exists(offerId) == false)
            {
                return BadRequest();
            }

            if (await employerService.ExistsById(employeeId))
            {
                return BadRequest();
            }

            if (await offerService.IsApplied(offerId, employeeId))
            {
                return View("AlreadyApplied");
            }

            await offerService.ApplyForOfferAsync(offerId, employeeId);

            return View("ThankYouForApplying");
        }

    }
}
