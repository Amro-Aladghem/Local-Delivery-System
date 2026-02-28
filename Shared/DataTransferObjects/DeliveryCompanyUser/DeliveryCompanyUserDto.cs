using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DeliveryCompanyUser
{
    public class DeliveryCompanyUserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int CountryId { get; set; }
        public string SystemRole { get; set; }

        public UserDeliveryCompany? UserDeliveryCompany { get; set; }
    }

    public record UserDeliveryCompany
    {
        public Guid DeliveryCompanyId { get; set; }
        public string DeliveryCompanyName { get; set; }
        public string DeliveryCompanyImageUrl { get; set; }
        public string DeliveryCompanyRole { get; set; }
    }
}

