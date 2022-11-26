using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Models.OfferModels
{
    public class OfferViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CreatedOn { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Salary { get; set; }

        public string Employer { get; set; }

        public string Location { get; set; }

        public string Seniority { get; set; }
    }
}
