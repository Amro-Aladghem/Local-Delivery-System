using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DeliveryClientUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public Guid DeliveryClientOrganizationId { get; set; }
        public DateTime LastLoggedInDateTime { get; set; }
        public DeliveryClientOrgUserRole DeliveryClientOrgUserRole { get; set; }

        public DeliveryClientOrganization DeliveryClientOrganization { get; set; }
        public User User { get; set; }
    }
}
