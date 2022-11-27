using JobPortalProject.Core.Models.OfferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Contracts
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferViewModel>> GetAllAsync(int categoryId);

        Task<OfferViewModel> GetOfferAsync(int offerId);

        Task ApplyForOfferAsync(int offerId, string employeeId);

        Task<bool> IsApplied(int offerId, string employeeId);
    }
}
