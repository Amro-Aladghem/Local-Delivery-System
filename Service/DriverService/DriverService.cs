using AutoMapper;
using Entities.Models;
using Enums;
using Repository;
using Service.Contracts;
using Shared.DataTransferObjects.Driver;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DriverService
{
    public class DriverService : IDriver
    {
        private readonly IAuthService _authService;
        private readonly ManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public DriverService(IAuthService authService, ManagerRepository managerRepository, IMapper mapper)
        {
            _authService = authService;
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        private async Task<bool> CreateDriverUser(AddDriverRequest addDriverRequest, Guid DeliveryCompanyId,Guid UserId)
        {
            Driver driver = _mapper.Map<Driver>(addDriverRequest);

            driver.UserId = UserId;
            driver.DeliveryCompanyId = DeliveryCompanyId;

            _managerRepository.Driver.CreateDriver(driver);

            return await _managerRepository.SaveAsync();
        }
        public async Task<bool> HandleCreateDriverUserForDeliveryCompany(AddDriverRequest addDriverRequest, Guid DeliveryCompanyId)
        {
            using (var transaction = await _managerRepository.BeginTransactionAsync())
            {
                try
                {
                    UserForAuthenticationResponse? user = await _authService
                        .CreateUserByManagerRole(addDriverRequest,SystemUserRoles.Driver.ToString(),addDriverRequest.Password);

                    if (user is null)
                        throw new Exception("Failed to create user for driver");

                    bool IsAddingDone = await CreateDriverUser(addDriverRequest, DeliveryCompanyId, user.Id);

                    if (!IsAddingDone)
                        throw new Exception("Failed to create driver");

                    await _managerRepository.CommitTransactionAsync();
                    return true;
                }
                catch
                {
                   await _managerRepository.RollbackTransactionAsync();
                    return false;
                }
            }
        }
    }
}
