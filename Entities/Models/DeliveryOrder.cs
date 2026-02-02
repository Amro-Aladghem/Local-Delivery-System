using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DeliveryOrder
    {
        public Guid Id { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public Guid ClientDeliveryOrderId { get; set; }
        public Guid?DriverId { get; set; }
        public int DeliveryTypeId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone {  get; set; }
        public string? CustomerSecondPhone { get; set; }
        public string CustomerAddressUrl { get; set; }
        public int DeliveryOrderAddressId { get; set; }
        public bool Fragile { get; set; }
        public bool Flammable { get; set; }
        public bool RequiresRefrigeration { get; set; }
        public int DeliveryOrderStatusId { get; set; }
        public Guid ? AcceptedFromUserId { get; set; } // when it null that is mean the Driver by self Accepted it 
        public DateTime CreatedAt { get; set; }
        public string? ClientNote { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public decimal DeliveryFees { get; set; }
        public decimal? AdditionalFees { get; set; }
        public string? AdditionalFeesName { get; set; }
        public decimal Total { get; set; }
        public DateTime AcceptedAt { get; set; }
        public DateTime? EstimatedDateTimeofDelevired { get; set; }
        public int OrderSerialNumber { get; set; } //auto generated

        public DeliveryCompany DeliveryCompany { get; set; }
        public ClientDeliveryOrder ClientDeliveryOrder { get; set; }
        public Driver Driver { get; set; }
        public DeliveryOrderAddress DeliveryOrderAddress { get; set; }
        public DeliveryOrderStatus  DeliveryOrderStatus { get; set; }
        public DeliveryCompanyUser ? DeliveryCompanyUser { get; set; }
        public DeliveryType DeliveryType { get; set; }

    }
}
