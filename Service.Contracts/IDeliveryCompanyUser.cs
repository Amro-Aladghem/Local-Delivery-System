using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompany;
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
         Task<RegisterDeliveryCompanyUserResult?> CreateDeliveryCompanyUser(AddDeliveryCompanyUserDto request, Guid PreRegisterUserId);
         Task<bool> IsDeliveryCompanyUserHasManagerRole(Guid ProfileId);
         Task<bool> HandleCreateCompanyForUser(AddDeliveryCompanyRequest addDeliveryCompanyRequest, Guid ProfileId);
    }
}
