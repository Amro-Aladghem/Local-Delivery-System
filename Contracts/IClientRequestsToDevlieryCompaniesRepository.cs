using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientRequestsToDevlieryCompaniesRepository
    {
        void CreateClientRequestToDeliveryCompany(ClientRequestsToDevlieryCompanies ClientRequestsToDevlieryCompaniesRepository);
        void DeleteClientRequestToDeliveryCompany(ClientRequestsToDevlieryCompanies ClientRequestsToDevlieryCompanies);
        Task<ClientRequestsToDevlieryCompanies> GetClientRequestToDeliveryCompany(Guid Id, bool trackChanges);
        void UpdateClientRequestToDeliveryCompany(ClientRequestsToDevlieryCompanies clientRequestToDeliveryCompany);
    }
}
