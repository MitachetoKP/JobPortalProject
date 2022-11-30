using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.UserModels;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortalProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<Employee> userManager;

        private readonly SignInManager<Employee> signInManager;

        private readonly IEmployeeService employeeService;

        public UserController(
            UserManager<Employee> _userManager,
            SignInManager<Employee> _signInManager,
            IEmployeeService _employeeService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            employeeService = _employeeService;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Employee()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ShowUserInfo()
        {
            var employeeId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await employeeService.GetUser(employeeId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditInfo()
        {
            var employeeId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await employeeService.GetUser(employeeId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInfo(EmployeeViewModel model)
        {
            var employeeId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await employeeService.EditInfoAsync(employeeId, model.UserName, model.Email, model.CV);

            return RedirectToAction(nameof(ShowUserInfo));
        }
    }
}
