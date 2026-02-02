using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DeliveryCompanyDeliveryType // this entity has compointaion key
    {
        public Guid DeliveryCompanyId { get; set; }
        public int DeliveryTypeId { get; set; }
        public DateTime EstimatedDateTimeArriavle { get; set; }
        public decimal? AdditaionalFees { get; set; }   //by default is equal to zero 
        public DeliveryCompany DeliveryCompany { get; set; }
        public DeliveryType DeliveryType { get; set; }
    }
}
