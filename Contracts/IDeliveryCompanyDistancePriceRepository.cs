using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDeliveryCompanyDistancePriceRepository
    {
        void CreateDeliveryCompanyDistancePrice(DeliveryCompanyDistancePrice deliveryCompanyDistancePrice);
        void DeleteDeliveryCompanyDistancePrice(DeliveryCompanyDistancePrice deliveryCompanyDistancePrice);
        Task<DeliveryCompanyDistancePrice> GetDeliveryCompanyDistancePrice(int Id, bool trackChanges);
        void UpdateDeliveryCompanyDistancePrice(DeliveryCompanyDistancePrice deliveryCompanyDistancePrice);
    }
}
