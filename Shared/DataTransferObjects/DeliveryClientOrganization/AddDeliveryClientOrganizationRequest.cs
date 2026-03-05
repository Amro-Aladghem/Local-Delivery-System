using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DeliveryClientOrganization
{
    public record AddDeliveryClientOrganizationRequest
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string? FacebookPageUrl { get; set; }
        public string? InstagramPageUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
        public DeliveryClientOrgType DeliveryClientOrgType { get; set; }
        public int AvgDailyOrders { get; set; }
        public int AvgMonthlyOrders { get; set; }
    }
}
