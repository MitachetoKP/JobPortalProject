using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Infrastructure;
using JobPortalProject.Core.Models.EmployerModels;
using JobPortalProject.Core.Models.OfferModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalProject.Controllers
{
    [Authorize]
    public class EmployerController : Controller
    {
        private readonly IEmployerService employerService;
        private readonly ILocationService locationService;
        private readonly ISeniorityService seniorityService;
        private readonly ICategoryService categoryService;
        private readonly IOfferService offerService;

        public EmployerController(
            IEmployerService _employerService, 
            ILocationService _locationService,
            ISeniorityService _seniorityService,
            ICategoryService _categoryService,
            IOfferService _offerService)
        {
            employerService = _employerService;
            locationService = _locationService;
            seniorityService = _seniorityService;
            categoryService = _categoryService;
            offerService = _offerService;
        }

        public async Task<IActionResult> Become(BecomeEmployerFormModel model)
        {
            var userId = User.Id();

            if (await employerService.ExistsById(userId))
            {
                return BadRequest();
            }

            if (employerService.EmployeeWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await employerService.CreateEmployerAsync(userId, model.PhoneNumber);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddOffer()
        {
            if (await employerService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(Become));
            }

            var model = new OfferFormModel()
            {
                Categories = await categoryService.GetAllAsync(),
                Locations = await locationService.GetAllAsync(),
                Seniorities = await seniorityService.GetAllAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer(OfferFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await employerService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(Become));
            }

            if (await categoryService.CategoryExists(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (await locationService.LocationExists(model.LocationId))
            {
                ModelState.AddModelError(nameof(model.LocationId), "Location does not exist.");
            }

            if (await seniorityService.SeniorityExists(model.SeniorityId))
            {
                ModelState.AddModelError(nameof(model.SeniorityId), "Seniority does not exist.");
            }

            int employerId = await employerService.GetEmployerId(User.Id());

            await employerService.CreateOfferAsync(model.Title, model.Description,
                model.Salary, model.LocationId, model.SeniorityId, 
                model.CategoryId, employerId);

            return RedirectToAction(nameof(MyOffers));
        }

        public async Task<IActionResult> MyOffers()
        {
            if (await employerService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(Become));
            }

            int employerId = await employerService.GetEmployerId(User.Id());

            var model = await employerService.GetMyOffersAsync(employerId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditOffer(int offerId)
        {
            if (await offerService.Exists(offerId) == false)
            {
                return BadRequest();
            }

            if (await offerService.HasEmployerWithIdAsync(offerId, User.Id()) == false)
            {
                return Unauthorized();
            }

            var offer = await offerService.GetOfferAsync(offerId);

            var categoryId = await categoryService.GetCategoryIdAsync(offerId);
            var locationId = await locationService.GetLocationIdAsync(offerId);
            var seniorityId = await seniorityService.GetSeniorityIdAsync(offerId);

            var model = new OfferFormModel()
            {
                Title = offer.Title,
                Description = offer.Description,
                Salary = decimal.Parse(offer.Salary),
                CategoryId = categoryId,
                LocationId = locationId,
                SeniorityId = seniorityId,
                Categories = await categoryService.GetAllAsync(),
                Locations = await locationService.GetAllAsync(),
                Seniorities = await seniorityService.GetAllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOffer(int offerId, OfferFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await offerService.Exists(offerId) == false)
            {
                return View();
            }

            if (await offerService.HasEmployerWithIdAsync(offerId, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await categoryService.CategoryExists(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (await locationService.LocationExists(model.LocationId))
            {
                ModelState.AddModelError(nameof(model.LocationId), "Location does not exist.");
            }

            if (await seniorityService.SeniorityExists(model.SeniorityId))
            {
                ModelState.AddModelError(nameof(model.SeniorityId), "Seniority does not exist.");
            }

            await employerService.EditfferAsync(offerId, model.Title, 
                model.Description, model.Salary, model.LocationId, 
                model.SeniorityId, model.CategoryId);

            return RedirectToAction("ShowSingleOffer", "Offer", new { offerId = offerId });
        }

        public async Task<IActionResult> RemoveOffer(int offerId)
        {
            if (await offerService.Exists(offerId) == false)
            {
                return BadRequest();
            }

            if (await offerService.HasEmployerWithIdAsync(offerId, User.Id()) == false)
            {
                return Unauthorized();
            }

            await employerService.DeleteAsync(offerId);

            return RedirectToAction(nameof(MyOffers));
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
