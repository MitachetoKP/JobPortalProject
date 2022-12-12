using JobPortalProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalProject.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IEmployeeService employeeService;

        public UserController(IEmployeeService _employeeService)
        {
            this.employeeService = _employeeService;
        }

        public async Task<IActionResult> All()
        {
            var model = await employeeService.GetAllAsync();

            return View(model);
        }
    }
}
