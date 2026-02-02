using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class DeliveryCompanyDistancePrice
    {
        public int Id { get; set; }
        public Guid DeliveryCompanyId { get; set; }
        public decimal MinDistanceKm { get; set; }
        public decimal MaxDistanceKm { get; set; } 
        public decimal DeliveryFees { get; set; }
        public decimal? AdditionalFees { get; set; }
        public string? AdditionalFeesName { get; set; } // to tell the customer why the additional fees is put it in .
        public DeliveryCompany DeliveryCompany { get; set; }
    }
}
