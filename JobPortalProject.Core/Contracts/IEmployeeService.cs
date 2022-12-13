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
        /// <summary>
        /// Gets User by employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>User/Employee model</returns>
        Task<UserViewModel> GetUser(string employeeId);

        /// <summary>
        /// Edits the information about the user account
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="newUserName"></param>
        /// <param name="newEmail"></param>
        /// <param name="newCV"></param>
        /// <returns></returns>
        Task EditInfoAsync(string employeeId, string newUserName, string newEmail, string newCV);


        /// <summary>
        /// Gets all registered users
        /// </summary>
        /// <returns>List of User models</returns>
        Task<IEnumerable<UserModel>> GetAllAsync();
    }
}
