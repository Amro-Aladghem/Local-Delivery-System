using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(100)]
        public string? NameAr { get; set; }

        [Required]
        public int CountryId { get; set; }

        // Optimistic concurrency token
        [Timestamp]
        public byte[] RowVersion { get; set; } = default!;

        // Relationships
        public virtual ICollection<ClientDeliveryOrder> ClientDeliveryOrders { get; set; } = new List<ClientDeliveryOrder>();
        public virtual Country Country { get; set; } = default!;
    }
}
