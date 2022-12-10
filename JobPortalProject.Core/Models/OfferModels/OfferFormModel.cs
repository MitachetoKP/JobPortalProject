using JobPortalProject.Core.Models.CategoryModels;
using JobPortalProject.Core.Models.LocationModels;
using JobPortalProject.Core.Models.SeniorityModels;
using System.ComponentModel.DataAnnotations;

namespace JobPortalProject.Core.Models.OfferModels
{
    public class OfferFormModel
    {
        [Required]
        [MinLength(5), MaxLength(25)]
        public string Title { get; init; }

        [Required]
        [MinLength(10), MaxLength(1000)]
        public string Description { get; init; }

        [Required]
        [Range(0.00, 100000)]
        public decimal Salary { get; init; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        [Required]
        public int EmployerId { get; init; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; init; }

        [Required]
        [Display(Name = "Seniority")]
        public int SeniorityId { get; init; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public IEnumerable<LocationViewModel> Locations { get; set; } = new List<LocationViewModel>();

        public IEnumerable<SeniorityViewModel> Seniorities { get; set; } = new List<SeniorityViewModel>();
    }
}
