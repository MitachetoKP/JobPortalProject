using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Models.EmployerModels
{
    public class BecomeEmployerFormModel
    {
        [Required]
        [MaxLength(15), MinLength(7)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; init; }
    }
}
