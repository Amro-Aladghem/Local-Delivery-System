using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Driver
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public string DrivingLicenseImageUrl { get; set; }
        public string VechicalNumber { get; set; }
        public int VechicalTypeId { get; set; }
        public DateTime LastLoggedInTime { get; set; }

        public DeliveryCompany DeliveryCompany { get; set; }
        public VechicalType VechicalType { get; set; }
        public User User { get; set; }

    }
}
