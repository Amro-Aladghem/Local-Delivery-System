using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.InternalModels
{
    public class DeliveryClientUserModel
    {
        public Guid Id { get; set; }
        public DeliveryClientOrgUserRole? DeliveryClientOrgUserRole { get; set; }
        public Guid? DeliveryClientOrganizationId { get; set; }
    }
}
