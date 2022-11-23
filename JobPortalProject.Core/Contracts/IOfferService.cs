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
        Task<IEnumerable<AllOfferViewModel>> GetAllAsync(int categoryId);
    }
}
