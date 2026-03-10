using Shared.DataTransferObjects.DeliveryClientOrganization;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.InternalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDeliveryClientUser
    {
        Task<RegisterDeliveryClientUserResult?> CreateDeliveryClientUser(AddDeliveryClientUserRequest request, Guid PreRegisterUserId);
        Task<DeliveryClientUserModel> GetDeliveryClientUserModel(Guid ProfileId);
        Task<bool> HandleCreateClientOrgForUser(AddDeliveryClientOrganizationRequest addDeliveryCompanyRequest, Guid ProfileId);
        Task<bool> HandleCreateAdminUserForOrg(AddDeliveryClientAdminRequest addDeliveryClientAdminRequest, Guid DeliveryClientOrgId);
    }
}
