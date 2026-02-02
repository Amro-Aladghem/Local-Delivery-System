using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryOrderRepository
    {
        void CreateDeliveryOrder(DeliveryOrder deliveryOrder);
        void DeleteDeliveryOrder(DeliveryOrder deliveryOrder);
        Task<DeliveryOrder> GetDeliveryOrder(Guid Id, bool trackChanges);
        void UpdateDeliveryOrder(DeliveryOrder deliveryOrder);
    }
}
