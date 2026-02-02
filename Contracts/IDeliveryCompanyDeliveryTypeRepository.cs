using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryCompanyDeliveryTypeRepository
    {
        void CreateDeliveryCompanyDeliveryType(DeliveryCompanyDeliveryType deliveryCompanyDeliveryType);
        void DeleteDeliveryCompanyDeliveryType(DeliveryCompanyDeliveryType deliveryCompanyDeliveryType);
        Task<DeliveryCompanyDeliveryType> GetDeliveryCompanyDeliveryTypeByDeliveryCompanyId(Guid DeliveryCompanyId, bool trackChanges);
        void UpdateDeliveryCompanyDeliveryType(DeliveryCompanyDeliveryType deliveryCompanyDeliveryType);
    }
}
