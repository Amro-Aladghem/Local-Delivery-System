using AutoMapper;
using Entities.Models;
using Repository;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DeliveryCompanyService
{
    public class DeliveryCompanyService : IDeliveryCompany
    {
        private readonly ManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public DeliveryCompanyService(ManagerRepository managerRepository,IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }
        public async Task<Guid?> CreateDeliveryCompany(AddDeliveryCompanyRequest request)
        {
            DeliveryCompany deliveryCompany = _mapper.Map<DeliveryCompany>(request);
            deliveryCompany.IsActive = true;

            _managerRepository.DeliveryCompany.CreateDeliveryCompany(deliveryCompany);

            if (!await _managerRepository.SaveAsync())
                return null;

            return deliveryCompany.Id;
        }
    }
}
