using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClientDeliveryOrder
    {
        public Guid Id { get; set; }
        public Guid DeliveryClientUserId { get; set; }
        public Guid DeliveryClientOrganizationId { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public int DeliveryTypeId { get; set; }
        public int ClientDeliveryOrderStatusId { get; set; }
        public string ReceiverFirstName { get;set; }
        public string ReceiverLastName { get;set; }
        public string ReceiverPhone { get;set; }
        public string? ReceiverSecondPhone { get; set; }
        public string Description { get; set; }
        public string GoogleMapUrl { get; set; }
        public int CityId { get; set; }
        public bool Fragile { get; set; }
        public bool Flammable { get; set; }
        public bool RequiresRefrigeration { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ClientNote { get; set; }
        public decimal TotalPrice { get; set; }
        public string ? RejectedNote { get; set; }

        public DeliveryClientUser DeliveryClientUser { get; set; }
        public DeliveryClientOrganization DeliveryClientOrganization { get; set; }
        public DeliveryCompany DeliveryCompany { get; set; }
        public ClientDeliveryOrderStatus ClientDeliveryOrderStatus { get; set; }
        public City City { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }
        public DeliveryType DeliveryType { get; set; }

    }
}
