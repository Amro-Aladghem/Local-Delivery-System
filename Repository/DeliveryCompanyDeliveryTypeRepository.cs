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
    public class DeliveryCompanyDeliveryTypeRepository : RepositoryBase<DeliveryCompanyDeliveryType>, IDeliveryCompanyDeliveryTypeRepository    
    {
        public DeliveryCompanyDeliveryTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryCompanyDeliveryType(DeliveryCompanyDeliveryType deliveryCompanyDeliveryType)
        {
            Create(deliveryCompanyDeliveryType);
        }
        public void DeleteDeliveryCompanyDeliveryType(DeliveryCompanyDeliveryType deliveryCompanyDeliveryType)
        {
            Delete(deliveryCompanyDeliveryType);
        }
        public async Task<DeliveryCompanyDeliveryType> GetDeliveryCompanyDeliveryTypeByDeliveryCompanyId(Guid Id, bool trackChanges)
        {
            DeliveryCompanyDeliveryType? deliveryCompanyDeliveryType = await FindByCondition(D => D.DeliveryCompanyId == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryCompanyDeliveryType == null)
                throw new EntityWithGuidNotFound(Id, nameof(DeliveryCompanyDeliveryType));

            return deliveryCompanyDeliveryType!;
        }
        public void UpdateDeliveryCompanyDeliveryType(DeliveryCompanyDeliveryType deliveryCompanyDeliveryType)
        {
            Update(deliveryCompanyDeliveryType);
        }
    }
}
