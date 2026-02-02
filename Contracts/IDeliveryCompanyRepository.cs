using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDeliveryCompanyRepository
    {
        void CreateDeliveryCompany(DeliveryCompany deliveryCompany);
        void DeleteDeliveryCompany(DeliveryCompany deliveryCompany);
        Task<DeliveryCompany> GetDeliveryCompany(Guid Id, bool trackChanges);
        void UpdateDeliveryCompany(DeliveryCompany deliveryCompany);
    }
}
