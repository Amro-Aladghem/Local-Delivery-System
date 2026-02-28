using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompanyUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDeliveryCompanyUser
    {
        public Task<RegisterDeliveryCompanyUserResult?> CreateDeliveryCompanyUser(AddDeliveryCompanyUserDto request, Guid PreRegisterUserId);
    }
}
