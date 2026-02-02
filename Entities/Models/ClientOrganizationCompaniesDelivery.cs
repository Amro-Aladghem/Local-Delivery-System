using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClientOrganizationCompaniesDelivery
    {
        public int Id { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public Guid DeliveryClientOrganizationId { get; set; }
        public bool IsActive { get; set; } //by default it true 

        public DeliveryCompany DeliveryCompany { get; set; }
        public DeliveryClientOrganization DeliveryClientOrganization { get; set; }
    }
}
