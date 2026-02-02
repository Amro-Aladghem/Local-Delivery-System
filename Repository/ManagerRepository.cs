using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly RepositoryContext _repositoryContext;

        private Lazy<IClientDeliveryOrderRepository> _clientDeliveryOrderRepository;
        private Lazy<IClientOrganizationCompaniesDeliveryRepository> _clientOrganizationCompaniesDeliveryRepository;
        private Lazy<IClientRequestsToDevlieryCompaniesRepository> _clientRequestsToDevlieryCompaniesRepository;
        private Lazy<IDeliveryClientOrganizationRepository> _deliveryClientOrganizationRepository;
        private Lazy<IDeliveryClientOrgProductRepository> _deliveryClientOrgProductRepository;
        private Lazy<IDeliveryClientUserRepository> _deliveryClientUserRepository;
        private Lazy<IDeliveryCompanyRepository> _deliveryCompanyRepository;
        private Lazy<IDeliveryCompanyCitiesPriceRepository> _deliveryCompanyCitiesPriceRepository;
        private Lazy<IDeliveryCompanyDeliveryTypeRepository> _deliveryCompanyDeliveryTypeRepository;
        private Lazy<IDeliveryCompanyDistancePriceRepository> _deliveryCompanyDistancePriceRepository;
        private Lazy<IDeliveryCompanyUserRepository> _deliveryCompanyUserRepository;
        private Lazy<IDeliveryOrderRepository> _deliveryOrderRepository;
        private Lazy<IDeliveryOrderAddressRepository> _deliveryOrderAddressRepository;
        private Lazy<IDriverRepository> _driverRepository;
        private Lazy<IDriverAssignmentRepository> _driverAssignmentRepository;

        public ManagerRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _clientDeliveryOrderRepository = new Lazy<IClientDeliveryOrderRepository>(() =>
                new ClientDeliveryOrderRepository(_repositoryContext));

            _clientOrganizationCompaniesDeliveryRepository = new Lazy<IClientOrganizationCompaniesDeliveryRepository>(() =>
                new ClientOrganizationCompaniesDeliveryRepository(_repositoryContext));

            _clientRequestsToDevlieryCompaniesRepository = new Lazy<IClientRequestsToDevlieryCompaniesRepository>(() =>
                new ClientRequestsToDevlieryCompaniesRepository(_repositoryContext));

            _deliveryClientOrganizationRepository = new Lazy<IDeliveryClientOrganizationRepository>(() =>
                new DeliveryClientOrganizationRepository(_repositoryContext));

            _deliveryClientOrgProductRepository = new Lazy<IDeliveryClientOrgProductRepository>(() =>
                new DeliveryClientOrgProductRepository(_repositoryContext));

            _deliveryClientUserRepository = new Lazy<IDeliveryClientUserRepository>(() =>
                new DeliveryClientUserRepository(_repositoryContext));

            _deliveryCompanyRepository = new Lazy<IDeliveryCompanyRepository>(() =>
                new DeliveryCompanyRepositroy(_repositoryContext));

            _deliveryCompanyCitiesPriceRepository = new Lazy<IDeliveryCompanyCitiesPriceRepository>(() =>
                new DeliveryCompanyCitiesPriceRepository(_repositoryContext));

            _deliveryCompanyDeliveryTypeRepository = new Lazy<IDeliveryCompanyDeliveryTypeRepository>(() =>
                new DeliveryCompanyDeliveryTypeRepository(_repositoryContext));

            _deliveryCompanyDistancePriceRepository = new Lazy<IDeliveryCompanyDistancePriceRepository>(() =>
                new DeliveryCompanyDistancePriceRepository(_repositoryContext));

            _deliveryCompanyUserRepository = new Lazy<IDeliveryCompanyUserRepository>(() =>
                new DeliveryCompanyUserRepository(_repositoryContext));

            _deliveryOrderRepository = new Lazy<IDeliveryOrderRepository>(() =>
                new DeliveryOrderRepository(_repositoryContext));

            _deliveryOrderAddressRepository = new Lazy<IDeliveryOrderAddressRepository>(() =>
                new DeliveryOrderAddressRepository(_repositoryContext));

            _driverRepository = new Lazy<IDriverRepository>(() =>
                new DriverRepository(_repositoryContext));

            _driverAssignmentRepository = new Lazy<IDriverAssignmentRepository>(() =>
                new DriverAssignmentRepository(_repositoryContext));
        }

        public IClientDeliveryOrderRepository ClientDeliveryOrder => _clientDeliveryOrderRepository.Value;
        public IClientOrganizationCompaniesDeliveryRepository ClientOrganizationCompaniesDelivery => _clientOrganizationCompaniesDeliveryRepository.Value;
        public IClientRequestsToDevlieryCompaniesRepository ClientRequestsToDevlieryCompanies => _clientRequestsToDevlieryCompaniesRepository.Value;
        public IDeliveryClientOrganizationRepository DeliveryClientOrganization => _deliveryClientOrganizationRepository.Value;
        public IDeliveryClientOrgProductRepository DeliveryClientOrgProduct => _deliveryClientOrgProductRepository.Value;
        public IDeliveryClientUserRepository DeliveryClientUser => _deliveryClientUserRepository.Value;
        public IDeliveryCompanyRepository DeliveryCompany => _deliveryCompanyRepository.Value;
        public IDeliveryCompanyCitiesPriceRepository DeliveryCompanyCitiesPrice => _deliveryCompanyCitiesPriceRepository.Value;
        public IDeliveryCompanyDeliveryTypeRepository DeliveryCompanyDeliveryType => _deliveryCompanyDeliveryTypeRepository.Value;
        public IDeliveryCompanyDistancePriceRepository DeliveryCompanyDistancePrice => _deliveryCompanyDistancePriceRepository.Value;
        public IDeliveryCompanyUserRepository DeliveryCompanyUser => _deliveryCompanyUserRepository.Value;
        public IDeliveryOrderRepository DeliveryOrder => _deliveryOrderRepository.Value;
        public IDeliveryOrderAddressRepository DeliveryOrderAddress => _deliveryOrderAddressRepository.Value;
        public IDriverRepository Driver => _driverRepository.Value;
        public IDriverAssignmentRepository DriverAssignment => _driverAssignmentRepository.Value;

        public async Task<bool> SaveAsync()
        {
            return await _repositoryContext.SaveChangesAsync() > 0;
        }
    }
}