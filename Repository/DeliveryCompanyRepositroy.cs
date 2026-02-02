using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DeliveryCompanyRepositroy : RepositoryBase<DeliveryCompany>,IDeliveryCompanyRepository
    {
        public DeliveryCompanyRepositroy(RepositoryContext repositoryContext)
            : base(repositoryContext)
            { }

        public void CreateDeliveryCompany(DeliveryCompany deliveryCompany)
        {
            Create(deliveryCompany);
        }

        public void DeleteDeliveryCompany(DeliveryCompany deliveryCompany)
        {
            Delete(deliveryCompany);
        }

        public async Task<DeliveryCompany> GetDeliveryCompany(Guid Id, bool trackChanges)
        {
            DeliveryCompany? deliveryCompany =  await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if(deliveryCompany == null) 
               throw new EntityWithGuidNotFound(Id,nameof(DeliveryCompany));

            return deliveryCompany!;
        }

        public void UpdateDeliveryCompany(DeliveryCompany deliveryCompany)
        {
            Update(deliveryCompany);
        }
    }
}
