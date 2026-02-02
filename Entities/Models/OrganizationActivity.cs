using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrganizationActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DeliveryClientOrganization> DeliveryClientOrganizations { get; set; }
    }
}
