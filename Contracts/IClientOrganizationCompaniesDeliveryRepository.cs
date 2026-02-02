using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientOrganizationCompaniesDeliveryRepository
    {
        void CreateClientOrganizationCompaniesDelivery(ClientOrganizationCompaniesDelivery clientOrganizationCompaniesDelivery);
        void DeleteClientOrganizationCompaniesDelivery(ClientOrganizationCompaniesDelivery clientOrganizationCompaniesDelivery);
        void UpdateClientOrganizationCompaniesDelivery(ClientOrganizationCompaniesDelivery clientOrganizationCompaniesDelivery);    
        Task<ClientOrganizationCompaniesDelivery> GetClientOrganizationCompaniesDelivery(int Id, bool trackChanges);

        Task<ClientOrganizationCompaniesDelivery> GetByOrgCompanyAndDeliveryIdsAsync(Guid organizationCompanyId, Guid deliveryCompanyId, bool trackChanges);
    }
}
