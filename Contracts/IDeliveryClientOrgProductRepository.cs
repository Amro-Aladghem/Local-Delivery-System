using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryClientOrgProductRepository
    {
        void CreateDeliveryClientOrgProduct(DeliveryClientOrgProduct deliveryClientOrgProduct);
        void DeleteDeliveryClientOrgProduct(DeliveryClientOrgProduct deliveryClientOrgProduct);
        Task<DeliveryClientOrgProduct> GetDeliveryClientOrgProduct(Guid Id, bool trackChanges);
        void UpdateDeliveryClientOrgProduct(DeliveryClientOrgProduct deliveryClientOrgProduct);
    }
}
