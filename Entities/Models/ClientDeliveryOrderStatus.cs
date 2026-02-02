using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClientDeliveryOrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameAr { get; set; }

        public ICollection<ClientDeliveryOrderStatus> ClientDeliveryOrders { get; set; }
    }
}
