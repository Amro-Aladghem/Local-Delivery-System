using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryOrderAddressRepository
    {
        void CreateDeliveryOrderAddress(DeliveryOrderAddress deliveryOrderAddress);
        void DeleteDeliveryOrderAddress(DeliveryOrderAddress deliveryOrderAddress);
        Task<DeliveryOrderAddress> GetDeliveryOrderAddress(int Id, bool trackChanges);
        void UpdateDeliveryOrderAddress(DeliveryOrderAddress deliveryOrderAddress);
    }
}
