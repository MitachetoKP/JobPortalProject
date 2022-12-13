using JobPortalProject.Core.Models.LocationModels;

namespace JobPortalProject.Core.Contracts
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets all locations
        /// </summary>
        /// <returns>List of location models</returns>
        Task<IEnumerable<LocationViewModel>> GetAllAsync();

        /// <summary>
        /// Checks if a location exists
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>True or false if the location exists</returns>
        Task<bool> LocationExists(int locationId);

        /// <summary>
        /// Gets a location by an offerId
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>The locationId (int)</returns>
        Task<int> GetLocationIdAsync(int offerId);
    }
}
