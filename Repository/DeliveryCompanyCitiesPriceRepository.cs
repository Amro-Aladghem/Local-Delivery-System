using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions;
using Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeliveryCompanyCitiesPriceRepository : RepositoryBase<DeliveryCompanyCitiesPrice>, IDeliveryCompanyCitiesPriceRepository
    {
        public DeliveryCompanyCitiesPriceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryCompanyCitiesPrice(DeliveryCompanyCitiesPrice deliveryCompanyCitiesPrice)
        {
            Create(deliveryCompanyCitiesPrice);
        }
        public void DeleteDeliveryCompanyCitiesPrice(DeliveryCompanyCitiesPrice deliveryCompanyCitiesPrice)
        {
            Delete(deliveryCompanyCitiesPrice);
        }
        public async Task<DeliveryCompanyCitiesPrice> GetDeliveryCompanyCitiesPrice(int Id, bool trackChanges)
        {
            DeliveryCompanyCitiesPrice? deliveryCompanyCitiesPrice = await FindByCondition(DCCP => DCCP.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryCompanyCitiesPrice == null)
                throw new EntityWithIntNotFound(Id, nameof(DeliveryCompanyCitiesPrice));

            return deliveryCompanyCitiesPrice!;
        }
        public void UpdateDeliveryCompanyCitiesPrice(DeliveryCompanyCitiesPrice deliveryCompanyCitiesPrice)
        {
            Update(deliveryCompanyCitiesPrice);
        }
    }
}
