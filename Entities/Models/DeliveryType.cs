using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DeliveryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string NameAr {get;set; }

        public ICollection<DeliveryCompany> DeliveryCompanies { get; set; }
        public ICollection<ClientDeliveryOrder> ClientDeliveryOrders { get; set; }
        public ICollection<DeliveryOrder> DeliveryOrderOrders { get;set; }

    }
}
