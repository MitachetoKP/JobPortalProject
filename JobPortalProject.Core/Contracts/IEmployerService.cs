using JobPortalProject.Core.Models.OfferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Contracts
{
    public interface IEmployerService
    {
        /// <summary>
        /// Checks if employer exists by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True of false if the employer exists</returns>
        Task<bool> ExistsById(string userId);

        /// <summary>
        /// Checks if employer exists by phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>True of false if the employer exists</returns>
        Task<bool> EmployeeWithPhoneNumberExists(string phoneNumber);

        /// <summary>
        /// Creates an employer
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task CreateEmployerAsync(string employeeId, string phoneNumber);

        /// <summary>
        /// Creates a new offer
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="salary"></param>
        /// <param name="locationId"></param>
        /// <param name="seniorityId"></param>
        /// <param name="categoryId"></param>
        /// <param name="employerId"></param>
        /// <returns></returns>
        Task CreateOfferAsync(string title, string description, decimal salary,
            int locationId, int seniorityId, int categoryId, int employerId);

        /// <summary>
        /// Gets an employer id by the user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Employer' id (int)</returns>
        Task<int> GetEmployerId(string userId);

        /// <summary>
        /// Gets all offers of the current employer
        /// </summary>
        /// <param name="employerId"></param>
        /// <returns>List of offer models</returns>
        Task<IEnumerable<OfferViewModel>> GetMyOffersAsync(int employerId);

        /// <summary>
        /// Edits the information of a selected offer
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="salary"></param>
        /// <param name="locationId"></param>
        /// <param name="seniorityId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task EditOfferAsync(int offerId, string title, string description,
            decimal salary, int locationId, int seniorityId, int categoryId);

        /// <summary>
        /// Deletes a selected offer
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        Task DeleteAsync(int offerId);
    }
}
