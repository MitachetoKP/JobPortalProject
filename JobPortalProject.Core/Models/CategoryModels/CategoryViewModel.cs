using JobPortalProject.Core.Models.OfferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Models.CategoryModels
{
    public class CategoryViewModel
    {
        public string Title { get; init; }

        public int Offers { get; set; }
    }
}
