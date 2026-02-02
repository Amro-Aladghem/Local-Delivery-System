using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientDeliveryOrderRepository
    {
        void CreateClientDeliveryOrder(ClientDeliveryOrder clientDeliveryOrder);
        void DeleteClientDeliveryOrder(ClientDeliveryOrder clientDeliveryOrder);
        Task<ClientDeliveryOrder> GetClientDeliveryOrder(Guid Id, bool trackChanges);
        void UpdateClientDeliveryOrder(ClientDeliveryOrder clientDeliveryOrder);
    }
}
