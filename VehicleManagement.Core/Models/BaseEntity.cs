using System;

namespace VehicleManagement.Core.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
