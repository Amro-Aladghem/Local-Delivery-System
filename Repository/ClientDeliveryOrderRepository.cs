using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClientDeliveryOrderRepository : RepositoryBase<ClientDeliveryOrder>, IClientDeliveryOrderRepository
    {
        public ClientDeliveryOrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateClientDeliveryOrder(ClientDeliveryOrder clientDeliveryOrder)
        {
            Create(clientDeliveryOrder);
        }

        public void DeleteClientDeliveryOrder(ClientDeliveryOrder clientDeliveryOrder)
        {
            Delete(clientDeliveryOrder);
        }

        public async Task<ClientDeliveryOrder> GetClientDeliveryOrder(Guid Id, bool trackChanges)
        {
            ClientDeliveryOrder? clientDeliveryOrder = await FindByCondition(cdo => cdo.Id == Id, trackChanges).SingleOrDefaultAsync();

            if(clientDeliveryOrder == null)
                throw new EntityWithGuidNotFound(Id, nameof(ClientDeliveryOrder));

            return clientDeliveryOrder!;
        }

        public void UpdateClientDeliveryOrder(ClientDeliveryOrder clientDeliveryOrder)
        {
            Update(clientDeliveryOrder);
        }
    }
}
