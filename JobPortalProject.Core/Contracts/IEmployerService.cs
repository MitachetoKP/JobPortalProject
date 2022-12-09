using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Contracts
{
    public interface IEmployerService
    {
        bool ExistsById(string userId);

        bool EmployeeWithPhoneNumberExists(string phoneNumber);

        Task CreateEmployerAsync(string employeeId, string phoneNumber);
    }
}
