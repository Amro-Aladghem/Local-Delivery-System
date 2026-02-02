using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class DeliveryClientOrgProduct
    {
        public Guid Id { get; set; }
        public Guid DeliveryClientOrganizationId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }

        public DeliveryClientOrganization DeliveryClientOrganization { get; set; }
    }
}
