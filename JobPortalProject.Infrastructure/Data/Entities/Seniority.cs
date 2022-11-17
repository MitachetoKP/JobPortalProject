using System.ComponentModel.DataAnnotations;

namespace JobPortalProject.Infrastructure.Data.Entities
{
    public class Seniority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Level { get; set; }

        public IEnumerable<Offer> Offers { get; set; } = new List<Offer>();
    }
}
