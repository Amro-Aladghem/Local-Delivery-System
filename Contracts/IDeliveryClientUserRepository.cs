using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryClientUserRepository
    {
        void CreateDeliveryClientUser(DeliveryClientUser deliveryClientUser);
        void DeleteDeliveryClientUser(DeliveryClientUser deliveryClientUser);
        Task<DeliveryClientUser> GetDeliveryClientUser(Guid Id, bool trackChanges);
        void UpdateDeliveryClientUser(DeliveryClientUser deliveryClientUser);
    }
}
