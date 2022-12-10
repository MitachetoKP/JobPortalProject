using JobPortalProject.Core.Models.LocationModels;

namespace JobPortalProject.Core.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationViewModel>> GetAllAsync();

        Task<bool> LocationExists(int locationId);
    }
}
