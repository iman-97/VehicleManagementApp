using System.ComponentModel.DataAnnotations;

namespace VehicleManagement.Core.Models
{
    public class Vehicle : BaseEntity
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Vehicle Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Vehicle Color")]
        public string Color { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Vehicle Tag")]
        public string Tag { get; set; }
        public bool IsBusy { get; set; }
    }
}
