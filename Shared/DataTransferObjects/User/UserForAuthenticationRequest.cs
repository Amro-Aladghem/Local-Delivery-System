using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.User
{
    public record UserForAuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }    
        public string PhoneNumber { get; set; }
    }
}
