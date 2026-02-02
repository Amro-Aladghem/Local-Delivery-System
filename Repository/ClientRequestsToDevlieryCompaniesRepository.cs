using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Entities.Exceptions;


namespace Repository
{
    public class ClientRequestsToDevlieryCompaniesRepository : RepositoryBase<ClientRequestsToDevlieryCompanies>, IClientRequestsToDevlieryCompaniesRepository  
    {
        public ClientRequestsToDevlieryCompaniesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }

        public void CreateClientRequestToDeliveryCompany(ClientRequestsToDevlieryCompanies ClientRequestsToDevlieryCompaniesRepository)
        {
           Create(ClientRequestsToDevlieryCompaniesRepository);
        }

        public void DeleteClientRequestToDeliveryCompany(ClientRequestsToDevlieryCompanies ClientRequestsToDevlieryCompanies)
        {
            Delete(ClientRequestsToDevlieryCompanies);
        }

        public async Task<ClientRequestsToDevlieryCompanies> GetClientRequestToDeliveryCompany(Guid Id, bool trackChanges)
        {
            ClientRequestsToDevlieryCompanies? clientRequestsToDevlieryCompanies = await FindByCondition(C => C.Id == Id, trackChanges).SingleOrDefaultAsync();

            if(clientRequestsToDevlieryCompanies == null)
                throw new EntityWithGuidNotFound(Id, nameof(ClientRequestsToDevlieryCompanies));

            return clientRequestsToDevlieryCompanies!;
        }

        public void UpdateClientRequestToDeliveryCompany(ClientRequestsToDevlieryCompanies clientRequestToDeliveryCompany)
        {
            Update(clientRequestToDeliveryCompany);
        }
    }
}
