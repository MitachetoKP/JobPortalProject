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
        Task<UserViewModel> GetUser(string employeeId);

        Task EditInfoAsync(string employeeId, string newUserName, string newEmail, string newCV);

        Task<IEnumerable<UserModel>> GetAllAsync();
    }
}
