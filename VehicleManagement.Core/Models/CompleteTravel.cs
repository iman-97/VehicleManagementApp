namespace VehicleManagement.Core.Models
{
    public class CompleteTravel : BaseEntity
    {
        public int TravelId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
    }
}
