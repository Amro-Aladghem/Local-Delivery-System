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
    public class DeliveryClientOrganizationRepository : RepositoryBase<DeliveryClientOrganization>, IDeliveryClientOrganizationRepository
    {
        public DeliveryClientOrganizationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }

        public void CreateDeliveryClientOrganization(DeliveryClientOrganization deliveryClientOrganization)
        {
            Create(deliveryClientOrganization);
        }

        public void DeleteDeliveryClientOrganization(DeliveryClientOrganization deliveryClientOrganization)
        {
            Delete(deliveryClientOrganization);
        }

        public async Task<DeliveryClientOrganization> GetDeliveryClientOrganization(Guid Id, bool trackChanges)
        {
            DeliveryClientOrganization? deliveryClientOrganization = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryClientOrganization == null)
                throw new EntityWithGuidNotFound(Id, nameof(DeliveryClientOrganization));

            return deliveryClientOrganization!;
        }

        public void UpdateDeliveryClientOrganization(DeliveryClientOrganization deliveryClientOrganization)
        {
            Update(deliveryClientOrganization);
        }
    }
}
