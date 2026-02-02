using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IManagerRepository
    {
        public IClientDeliveryOrderRepository ClientDeliveryOrder { get; }
        public IClientOrganizationCompaniesDeliveryRepository ClientOrganizationCompaniesDelivery { get; }
        public IClientRequestsToDevlieryCompaniesRepository ClientRequestsToDevlieryCompanies { get; }
        public IDeliveryClientOrganizationRepository DeliveryClientOrganization { get; }
        public IDeliveryClientOrgProductRepository DeliveryClientOrgProduct { get; }
        public IDeliveryClientUserRepository DeliveryClientUser { get; }
        public IDeliveryCompanyRepository DeliveryCompany { get; }
        public IDeliveryCompanyCitiesPriceRepository DeliveryCompanyCitiesPrice { get; }
        public IDeliveryCompanyDeliveryTypeRepository DeliveryCompanyDeliveryType { get; }
        public IDeliveryCompanyDistancePriceRepository DeliveryCompanyDistancePrice { get; }
        public IDeliveryCompanyUserRepository DeliveryCompanyUser { get; }
        public IDeliveryOrderRepository DeliveryOrder { get; }
        public IDeliveryOrderAddressRepository DeliveryOrderAddress { get; }
        public IDriverRepository Driver { get; }
        public IDriverAssignmentRepository DriverAssignment { get; }

        Task<bool> SaveAsync();
    }
}
