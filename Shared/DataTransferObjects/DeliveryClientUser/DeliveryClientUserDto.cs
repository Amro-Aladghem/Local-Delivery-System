using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DeliveryClientUser
{
    public record DeliveryClientUserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int CountryId { get; set; }
        public string SystemRole { get; set; }

        public UserDeliveryClientOrganization? DeliveryClientOrganization { get; set; }
    }

    public record UserDeliveryClientOrganization
    {
        public Guid DeliveryClientOrganizationId { get; set; }
        public string DeliveryClientOrganizationName { get; set; }
        public string DeliveryClientOrganizationImageUrl { get; set; }
        public string DeliveryClientOrganizationRole { get; set; }
    }
}
