using JobPortalProject.Core.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> GetPersonalInfo(string employeeId);
    }
}
