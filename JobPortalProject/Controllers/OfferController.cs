using JobPortalProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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

        //public IActionResult ApplyForOffer()
        //{

        //}
    }
}
