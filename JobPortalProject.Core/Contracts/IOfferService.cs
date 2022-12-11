using JobPortalProject.Core.Models.OfferModels;
using JobPortalProject.Core.Models.UserModels;

namespace JobPortalProject.Core.Contracts
{
    public interface IOfferService
    {
        Task<OfferListModel> GetAllAsync(int categoryId, int locationId);

        Task<OfferViewModel> GetOfferAsync(int offerId);

        Task ApplyForOfferAsync(int offerId, string employeeId);

        Task<bool> IsApplied(int offerId, string employeeId);

        Task<bool> Exists(int offerId);

        Task<bool> HasEmployerWithIdAsync(int offerId, string employeeId);

        Task<EmployeeListModel> GetAppliedAsync(int offerId);
    }
}
