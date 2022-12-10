using JobPortalProject.Core.Models.CategoryModels;
using JobPortalProject.Core.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Models.OfferModels
{
    public class OfferListModel
    {
        public CategoryViewModel Category { get; init; }

        public string Location { get; init; }

        public IEnumerable<LocationViewModel> Locations { get; set; } = new List<LocationViewModel>();

        public IEnumerable<OfferViewModel> Offers { get; set; } = new List<OfferViewModel>();
    }
}
