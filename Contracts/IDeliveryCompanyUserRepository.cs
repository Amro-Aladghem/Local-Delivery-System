using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryCompanyUserRepository
    {
        void CreateDeliveryCompanyUser(DeliveryCompanyUser deliveryCompanyUser);
        void DeleteDeliveryCompanyUser(DeliveryCompanyUser deliveryCompanyUser);
        Task<DeliveryCompanyUser> GetDeliveryCompanyUser(Guid Id, bool trackChanges);
        void UpdateDeliveryCompanyUser(DeliveryCompanyUser deliveryCompanyUser);
    }
}
