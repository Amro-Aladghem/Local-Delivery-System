using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeliveryOrderAddressRepository :RepositoryBase<DeliveryOrderAddress>, IDeliveryOrderAddressRepository
    {
        public DeliveryOrderAddressRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryOrderAddress(DeliveryOrderAddress deliveryOrderAddress)
        {
            Create(deliveryOrderAddress);
        }
        public void DeleteDeliveryOrderAddress(DeliveryOrderAddress deliveryOrderAddress)
        {
            Delete(deliveryOrderAddress);
        }
        public async Task<DeliveryOrderAddress> GetDeliveryOrderAddress(int Id, bool trackChanges)
        {
            DeliveryOrderAddress? deliveryOrderAddress = await FindByCondition(DOA => DOA.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryOrderAddress == null)
                throw new EntityWithIntNotFound(Id, nameof(DeliveryOrderAddress));

            return deliveryOrderAddress!;
        }
        public void UpdateDeliveryOrderAddress(DeliveryOrderAddress deliveryOrderAddress)
        {
            Update(deliveryOrderAddress);
        }
    }
}
