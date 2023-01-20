using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Core.Models;

namespace VehicleManagement.Core.ViewModels
{
    public class AssignTravelViewModel
    {
        public CompleteTravel CompleteTravel { get; set; }
        public Travel Travel { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
