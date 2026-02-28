using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DeliveryCompanyUser
{
    public class RegisterDeliveryCompanyUserResult
    {
        public DeliveryCompanyUserDto DeliveryCompanyUserDto { get; set; }
        public TokenDto TokenDto { get; set; }
    }
}
