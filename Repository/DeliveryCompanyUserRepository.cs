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
    public class DeliveryCompanyUserRepository : RepositoryBase<DeliveryCompanyUser>, IDeliveryCompanyUserRepository
    {   
        public DeliveryCompanyUserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDeliveryCompanyUser(DeliveryCompanyUser deliveryCompanyUser)
        {
            Create(deliveryCompanyUser);
        }
        public void DeleteDeliveryCompanyUser(DeliveryCompanyUser deliveryCompanyUser)
        {
            Delete(deliveryCompanyUser);
        }
        public async Task<DeliveryCompanyUser> GetDeliveryCompanyUser(Guid Id, bool trackChanges)
        {
            DeliveryCompanyUser? deliveryCompanyUser = await FindByCondition(DCU => DCU.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (deliveryCompanyUser == null)
                throw new EntityWithGuidNotFound(Id, nameof(DeliveryCompanyUser));

            return deliveryCompanyUser!;
        }
        public void UpdateDeliveryCompanyUser(DeliveryCompanyUser deliveryCompanyUser)
        {
            Update(deliveryCompanyUser);
        }
    }
}
