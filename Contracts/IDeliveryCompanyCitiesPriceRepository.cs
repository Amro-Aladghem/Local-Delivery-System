using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryCompanyCitiesPriceRepository
    {
        void CreateDeliveryCompanyCitiesPrice(DeliveryCompanyCitiesPrice deliveryCompanyCitiesPrice);
        void DeleteDeliveryCompanyCitiesPrice(DeliveryCompanyCitiesPrice deliveryCompanyCitiesPrice);
        Task<DeliveryCompanyCitiesPrice> GetDeliveryCompanyCitiesPrice(int Id, bool trackChanges);
        void UpdateDeliveryCompanyCitiesPrice(DeliveryCompanyCitiesPrice deliveryCompanyCitiesPrice);
    }
}
