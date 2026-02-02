using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public int CountryId { get; set; }
        public string? ReffreshToken { get; set; }
        public DateTime? ReffreshTokenExpired { get; set; }
        public bool IsActive { get; set; }
        public Country Country { get; set; }
    }
}
