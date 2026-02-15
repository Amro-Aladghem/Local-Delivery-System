using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.User
{
    public record UserPreRegisterResponse
    {
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserId { get; set;  }
        public string SystemRole { get; set; }
    }
}
