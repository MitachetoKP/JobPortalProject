using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Infrastructure;
using JobPortalProject.Core.Models.EmployerModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalProject.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IEmployerService employerService;

        public EmployerController(IEmployerService _employerService)
        {
            this.employerService = _employerService;
        }

        public async Task<IActionResult> Become(BecomeEmployerFormModel model)
        {
            var userId = User.Id();

            if (employerService.ExistsById(userId))
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
    }
}
