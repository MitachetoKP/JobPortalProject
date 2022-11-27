using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalProject.Infrastructure.Data.Entities
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [ForeignKey(nameof(Employer))]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        [Required]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        [ForeignKey(nameof(Seniority))]
        public int SeniorityId { get; set; }
        public Seniority Seniority { get; set; }

        public List<Employee> AppliedEmployees { get; set; } = new List<Employee>();
    }
}
