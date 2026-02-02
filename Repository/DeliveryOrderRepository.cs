using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts;
using Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeliveryOrderRepository :RepositoryBase<DeliveryOrder>, IDeliveryOrderRepository
    {
        public DeliveryOrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            Create(deliveryOrder);
        }
        public void DeleteDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            Delete(deliveryOrder);
        }
        public async Task<DeliveryOrder> GetDeliveryOrder(Guid Id, bool trackChanges)
        {
            DeliveryOrder? deliveryOrder = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();
            if (deliveryOrder == null)
                throw new EntityWithGuidNotFound(Id, nameof(DeliveryOrder));

            return deliveryOrder!;
        }
        public void UpdateDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            Update(deliveryOrder);
        }
    }
}
