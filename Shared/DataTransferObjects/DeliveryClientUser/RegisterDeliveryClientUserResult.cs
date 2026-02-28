using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DeliveryClientUser
{
    public class RegisterDeliveryClientUserResult
    {
        public DeliveryClientUserDto DeliveryClientUserDto { get; set; }
        public TokenDto TokenDto { get; set; }
    }
}
