using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleManagement.Core.Models
{
    public class Travel : BaseEntity
    {
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Passengers Count")]
        public byte PassengersCount { get; set; }

        [Display(Name = "Passenger First Name")]
        public string PassengerFirstName { get; set; }

        [Display(Name = "Passenger Last Name")]
        public string PassengerLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public TravelStatus TravelStatus { get; set; }
    }
}
