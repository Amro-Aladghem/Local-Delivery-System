using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities.Models
{
    //Not Here THe Delivery Company Can Add An Address without ClienterDliveryOrderId for this you must solve it 
    public class DeliveryOrderAddress
    {
        public int Id { get; set; }
        public Guid ClientDeliveryOrderId { get; set; } 
        public string? Street { get; set; }  
        public string? DepartmentNumber { get; set; }
        public int? FloorNumber { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public ClientDeliveryOrder ClientDeliveryOrders { get; set; }
        public ICollection<DeliveryOrder> DeliveryOrders { get; set; }
    }
}
