using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobPortalProject.Infrastructure.Data.Entities
{
    public class Employee : IdentityUser
    {
        public string CV { get; set; }

        public IEnumerable<Offer> AppliedOffers { get; set; } = new List<Offer>();
    }
}
