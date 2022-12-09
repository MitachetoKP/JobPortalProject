using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalProject.Infrastructure.Data.Entities
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public Employee User { get; set; }

        public IEnumerable<Offer> MyOffers { get; set; } = new List<Offer>();
    }
}
