using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Models
{
    public class Institution
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public DateTime DateOfRegister { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string? FacebookPageUrl { get; set; }
        public string? InstagramPageUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? description { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }

    }
}
