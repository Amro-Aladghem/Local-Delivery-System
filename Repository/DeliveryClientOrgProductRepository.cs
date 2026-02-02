using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Exceptions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeliveryClientOrgProductRepository : RepositoryBase<DeliveryClientOrgProduct>, IDeliveryClientOrgProductRepository 
    {
        public DeliveryClientOrgProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryClientOrgProduct(DeliveryClientOrgProduct deliveryClientOrgProduct)
        {
            Create(deliveryClientOrgProduct);
        }
        public void DeleteDeliveryClientOrgProduct(DeliveryClientOrgProduct deliveryClientOrgProduct)
        {
            Delete(deliveryClientOrgProduct);
        }
        public async Task<DeliveryClientOrgProduct> GetDeliveryClientOrgProduct(Guid Id, bool trackChanges)
        {
            DeliveryClientOrgProduct? deliveryClientOrgProduct = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryClientOrgProduct == null)
                throw new EntityWithGuidNotFound(Id, nameof(DeliveryClientOrgProduct));

            return deliveryClientOrgProduct!;
        }
        public void UpdateDeliveryClientOrgProduct(DeliveryClientOrgProduct deliveryClientOrgProduct)
        {
            Update(deliveryClientOrgProduct);
        }
    }
}
