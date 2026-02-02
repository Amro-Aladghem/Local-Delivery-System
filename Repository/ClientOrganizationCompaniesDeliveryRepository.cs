using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Entities.Exceptions;

namespace Repository
{
    public class ClientOrganizationCompaniesDeliveryRepository :RepositoryBase<ClientOrganizationCompaniesDelivery>, IClientOrganizationCompaniesDeliveryRepository
    {
        public ClientOrganizationCompaniesDeliveryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateClientOrganizationCompaniesDelivery(ClientOrganizationCompaniesDelivery clientOrganizationCompaniesDelivery)
        {
            Create(clientOrganizationCompaniesDelivery);
        }
        public void DeleteClientOrganizationCompaniesDelivery(ClientOrganizationCompaniesDelivery clientOrganizationCompaniesDelivery)
        {
            Delete(clientOrganizationCompaniesDelivery);
        }

        public async Task<ClientOrganizationCompaniesDelivery> GetByOrgCompanyAndDeliveryIdsAsync(Guid organizationCompanyId, Guid deliveryCompanyId, bool trackChanges)
        {
            ClientOrganizationCompaniesDelivery? clientOrganizationCompaniesDelivery = await FindByCondition(
                                                                                           c => c.DeliveryClientOrganizationId == organizationCompanyId 
                                                                                           && c.DeliveryCompanyId == deliveryCompanyId, trackChanges)
                                                                                           .SingleOrDefaultAsync();

            if (clientOrganizationCompaniesDelivery == null)
                throw new ClientOrgWithCompanyNotFound(organizationCompanyId, deliveryCompanyId);

            return clientOrganizationCompaniesDelivery!;
        }

        public async Task<ClientOrganizationCompaniesDelivery> GetClientOrganizationCompaniesDelivery(int Id, bool trackChanges)
        {
            ClientOrganizationCompaniesDelivery? clientOrganizationCompaniesDelivery = await FindByCondition(c => c.Id == Id, trackChanges).SingleOrDefaultAsync();
            
            if(clientOrganizationCompaniesDelivery == null)
                throw new EntityWithIntNotFound(Id, nameof(ClientOrganizationCompaniesDelivery));

            return clientOrganizationCompaniesDelivery!;
        }

        public void UpdateClientOrganizationCompaniesDelivery(ClientOrganizationCompaniesDelivery clientOrganizationCompaniesDelivery)
        {
            Update(clientOrganizationCompaniesDelivery);
        }
    }
}
