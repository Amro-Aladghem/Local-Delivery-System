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
    public class DeliveryCompanyDistancePriceRepository :RepositoryBase<DeliveryCompanyDistancePrice>, IDeliveryCompanyDistancePriceRepository
    {
        public DeliveryCompanyDistancePriceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryCompanyDistancePrice(DeliveryCompanyDistancePrice deliveryCompanyDistancePrice)
        {
            Create(deliveryCompanyDistancePrice);
        }
        public void DeleteDeliveryCompanyDistancePrice(DeliveryCompanyDistancePrice deliveryCompanyDistancePrice)
        {
            Delete(deliveryCompanyDistancePrice);
        }
        public async Task<DeliveryCompanyDistancePrice> GetDeliveryCompanyDistancePrice(int Id, bool trackChanges)
        {
            DeliveryCompanyDistancePrice? deliveryCompanyDistancePrice = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryCompanyDistancePrice == null)
                throw new EntityWithIntNotFound(Id, nameof(DeliveryCompanyDistancePrice));

            return deliveryCompanyDistancePrice!;
        }
        public void UpdateDeliveryCompanyDistancePrice(DeliveryCompanyDistancePrice deliveryCompanyDistancePrice)
        {
            Update(deliveryCompanyDistancePrice);
        }
    }
}
