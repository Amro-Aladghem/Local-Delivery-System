using Shared.DataTransferObjects.DeliveryClientOrganization;
using Shared.DataTransferObjects.DeliveryCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDeliveryClientOrganization
    {
        Task<Guid?> CreateDeliveryClientOrg(AddDeliveryClientOrganizationRequest request);
    }
}
