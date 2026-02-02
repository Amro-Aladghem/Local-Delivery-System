using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class DriverAssignment
    {
        public int Id { get; set; }
        public Guid DriverId { get; set; }
        public Guid? AssignedBy { get; set; } // this is DeliveryUserId , if null it is DriverBy Self Accepted
        public DateTime AssignedAt { get; set; }
        public DateTime AcceptedAt { get; set; }
        public DateTime? CompletedAt { get; set; }   
        public string? Note { get; set; }

        public Driver Driver { get; set; }
        public DeliveryCompanyUser DeliveryCompanyUser { get; set; }
    }
}
