using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.User
{
    public abstract class UserForRegisterationRequest
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
