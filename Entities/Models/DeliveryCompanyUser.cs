using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DeliveryCompanyUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public DeliveryCompanyUserRole DeliveryCompanyUserRole { get; set; }
        public DateTime LastLoggedInDateTime { get; set; }

        public DeliveryCompany DeliveryCompany { get; set; }
        public ICollection<DeliveryOrder> DeliveryOrders { get; set; }
        public ICollection<DriverAssignment> DriverAssignments { get; set; }
        public User User { get; set; }
    }
}
