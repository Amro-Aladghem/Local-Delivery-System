using AutoMapper;
using Entities.Models;
using Repository;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryClientOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Service.DeliveryClientOrganizationService
{
    public class DeliveryClientOrganizationService : IDeliveryClientOrganization
    {
        private readonly ManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public DeliveryClientOrganizationService(ManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateDeliveryClientOrg(AddDeliveryClientOrganizationRequest request)
        {
            DeliveryClientOrganization deliveryClientOrganization = _mapper.Map<DeliveryClientOrganization>(request);

            deliveryClientOrganization.OrganizationActivityId = (int)OrganizationActivties.DeliveryClientOrg; //default for now.

            _managerRepository.DeliveryClientOrganization.CreateDeliveryClientOrganization(deliveryClientOrganization);

            if (!await _managerRepository.SaveAsync())
                return null;

            return deliveryClientOrganization.Id;
        }
    }
}
