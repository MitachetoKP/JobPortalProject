using JobPortalProject.Core.Models.OfferModels;
using JobPortalProject.Core.Models.UserModels;

namespace JobPortalProject.Core.Contracts
{
    public interface IOfferService
    {
        /// <summary>
        /// Gets all offers filltered by category and location
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="locationId"></param>
        /// <returns>List model of all offers</returns>
        Task<OfferListModel> GetAllAsync(int categoryId, int locationId);

        /// <summary>
        /// Gets an offer by its id
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>Offer model</returns>
        Task<OfferViewModel> GetOfferAsync(int offerId);

        /// <summary>
        /// User applies for an offer
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task ApplyForOfferAsync(int offerId, string employeeId);

        /// <summary>
        /// Checks if the current user is applied for an offer
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="employeeId"></param>
        /// <returns>True or false if the user is applied</returns>
        Task<bool> IsApplied(int offerId, string employeeId);

        /// <summary>
        /// Checks if an offer exists by its id
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>True or false if the offer exists</returns>
        Task<bool> Exists(int offerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="employeeId"></param>
        /// <returns>Tre or false if an employer exists</returns>
        Task<bool> HasEmployerWithIdAsync(int offerId, string employeeId);

        /// <summary>
        /// Gets all applied users for the selected offer
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>list model of employee models</returns>
        Task<EmployeeListModel> GetAppliedAsync(int offerId);
    }
}
