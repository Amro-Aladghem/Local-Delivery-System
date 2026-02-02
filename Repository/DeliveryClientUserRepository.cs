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
    public class DeliveryClientUserRepository :RepositoryBase<DeliveryClientUser>, IDeliveryClientUserRepository
    {
        public DeliveryClientUserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryClientUser(DeliveryClientUser deliveryClientUser)
        {
            Create(deliveryClientUser);
        }
        public void DeleteDeliveryClientUser(DeliveryClientUser deliveryClientUser)
        {
            Delete(deliveryClientUser);
        }
        public async Task<DeliveryClientUser> GetDeliveryClientUser(Guid Id, bool trackChanges)
        {
            DeliveryClientUser? deliveryClientUser = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryClientUser == null)
                throw new EntityWithGuidNotFound(Id, nameof(DeliveryClientUser));

            return deliveryClientUser!;
        }
        public void UpdateDeliveryClientUser(DeliveryClientUser deliveryClientUser)
        {
            Update(deliveryClientUser);
        }
    }
}
