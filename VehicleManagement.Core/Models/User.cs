using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleManagement.Core.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Fisrt Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string IdentityUserId { get; set; }
        public ICollection<Travel> Travels { get; set; }

        public User()
        {
            Travels = new List<Travel>();
        }

    }
}
