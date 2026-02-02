using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DeliveryCompany : Institution
    {
        public DeliveryFeesCalculationByType DeliveryFeesCalculationByType { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }  

        public ICollection<DeliveryType> DeliveryTypes { get; set; }
       
    }
}
