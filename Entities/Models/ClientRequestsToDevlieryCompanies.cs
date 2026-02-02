using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class ClientRequestsToDevlieryCompanies
    {
        public Guid Id { get; set; }
        public Guid DeliveryClientUserId { get; set; }
        public Guid DeliveryClientOrganizationId { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public ClientRequestsStatus ClientRequestsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool HasAcceptedYet { get; set; }
        public string ?RejectedNote { get; set; }

        public DeliveryClientUser DeliveryClientUser { get; set; }
        public DeliveryClientOrganization DeliveryClientOrganization { get; set; }
        public DeliveryCompany DeliveryCompany { get; set; }
    }
}
