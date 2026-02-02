using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int CountryId { get; set; }

        public ICollection<ClientDeliveryOrder> ClientDeliveryOrders { get; set; }
        public Country Country { get; set; }
    }
}
