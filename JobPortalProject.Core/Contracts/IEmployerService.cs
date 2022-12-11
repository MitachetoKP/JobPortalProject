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
        Task<bool> ExistsById(string userId);

        bool EmployeeWithPhoneNumberExists(string phoneNumber);

        Task CreateEmployerAsync(string employeeId, string phoneNumber);

        Task CreateOfferAsync(
            string title,
            string description,
            decimal salary,
            int locationId,
            int seniorityId,
            int categoryId,
            int employerId);

        Task<int> GetEmployerId(string userId);

        Task<IEnumerable<OfferViewModel>> GetMyOffersAsync(int employerId);

        Task EditfferAsync(
            int offerId,
            string title,
            string description,
            decimal salary,
            int locationId,
            int seniorityId,
            int categoryId);
    }
}
