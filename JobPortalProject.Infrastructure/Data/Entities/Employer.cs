using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Infrastructure.Data.Entities
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        public IEnumerable<Offer> MyOffers { get; set; } = new List<Offer>();
    }
}
