using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using Enums;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryClientOrganization;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.Driver;
using Shared.DataTransferObjects.User;
using Shared.InternalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DeliveryClientUserService
{
    public class DeliveryClientUserService : IDeliveryClientUser
    {
        private readonly IAuthService _authService;
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        private readonly IDeliveryClientOrganization _deliveryClientOrganization;

        public DeliveryClientUserService(IAuthService authService, IManagerRepository managerRepository,IMapper mapper, IDeliveryClientOrganization deliveryClientOrganization)
        {
            _authService = authService;
            _managerRepository = managerRepository;
            _mapper = mapper;
            _deliveryClientOrganization = deliveryClientOrganization;
        }

        private RegisterDeliveryClientUserResult? MappingRegisterUser(UserForAuthenticationResponse authUser,TokenDto tokenDto)
        {
            DeliveryClientUserDto deliveryClientUser = _mapper.Map<DeliveryClientUserDto>(authUser);

            return new RegisterDeliveryClientUserResult() { DeliveryClientUserDto = deliveryClientUser,TokenDto = tokenDto };
        }

        public async Task<RegisterDeliveryClientUserResult?> CreateDeliveryClientUser(AddDeliveryClientUserRequest request, Guid PreRegisterUserId)
        {
            using (var transaction = await _managerRepository.BeginTransactionAsync())
            {
                try
                {
                    UserForAuthenticationResponse? authUser = await _authService.RegisterUser(request, PreRegisterUserId,SystemUserRoles.DeliveryClient.ToString());

                    if (authUser is null)
                        throw new Exception("Failed To Register User");

                    DeliveryClientUser deliveryClientUser = new DeliveryClientUser()
                    {
                        UserId = authUser.Id,
                        DeliveryClientOrgUserRole = DeliveryClientOrgUserRole.Manager
                    };

                    _managerRepository.DeliveryClientUser.CreateDeliveryClientUser(deliveryClientUser);

                    if (!await _managerRepository.SaveAsync())
                        throw new Exception("Failed To Create DeliveryClientUser");

                    TokenDto? tokenDto = await _authService.GenerateTokenForUser(deliveryClientUser.UserId, deliveryClientUser.Id);

                    if (tokenDto is null)
                        throw new Exception("Failed To Create DeliveryClientUser");

                    await _managerRepository.CommitTransactionAsync();

                    return MappingRegisterUser(authUser, tokenDto); 
                }
                catch
                {
                    await _managerRepository.RollbackTransactionAsync();
                    return null;
                }
            }
        }

        public async Task<bool> IsDeliveryClientUserHasManagerRole(Guid ProfileId)
        {
            DeliveryClientUser deliveryClientUser = await _managerRepository.DeliveryClientUser.GetDeliveryClientUser(ProfileId, false);

            return deliveryClientUser.DeliveryClientOrgUserRole == DeliveryClientOrgUserRole.Manager;
        }

        private async Task<bool> SetDeliveryClientOrgToUser(Guid ProfileId, Guid DeliveryClientOrgId)
        {
            DeliveryClientUser deliveryClientUser = await _managerRepository.DeliveryClientUser.GetDeliveryClientUser(ProfileId, true);

            deliveryClientUser.DeliveryClientOrganizationId = DeliveryClientOrgId;

            _managerRepository.DeliveryClientUser.UpdateDeliveryClientUser(deliveryClientUser);

            return await _managerRepository.SaveAsync();
        }


        public async Task<bool> HandleCreateClientOrgForUser(AddDeliveryClientOrganizationRequest addDeliveryCompanyRequest, Guid ProfileId)
        {
            using (var transaction = await _managerRepository.BeginTransactionAsync())
            {
                try
                {
                    Guid? DeliveryClientOrgId = await _deliveryClientOrganization.CreateDeliveryClientOrg(addDeliveryCompanyRequest);

                    if (DeliveryClientOrgId is null)
                        throw new Exception("Failed to  Create Delivery Client Org!");

                    bool IsDone = await SetDeliveryClientOrgToUser(ProfileId, DeliveryClientOrgId.Value);

                    if (IsDone)
                        throw new Exception("Failed to Create Delivery Company!");

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

        public async Task<DeliveryClientUserModel> GetDeliveryClientUserModel(Guid ProfileId)
        {
            DeliveryClientUser deliveryClientUser = await _managerRepository.DeliveryClientUser.GetDeliveryClientUser(ProfileId, false);

            return _mapper.Map<DeliveryClientUserModel>(deliveryClientUser);
        }

        public async Task<bool> HandleCreateAdminUserForOrg(AddDeliveryClientAdminRequest addDeliveryClientAdminRequest,Guid DeliveryClientOrgId)
        {
            using(var transaction = await _managerRepository.BeginTransactionAsync())
            {
                try
                {
                    UserForAuthenticationResponse? user = await _authService
                        .CreateUserByManagerRole(addDeliveryClientAdminRequest, SystemUserRoles.DeliveryClient.ToString(), addDeliveryClientAdminRequest.Password);

                    if (user is null)
                        throw new Exception("Failed to create user for driver");

                    DeliveryClientUser deliveryClientUser = new DeliveryClientUser()
                    {
                        UserId = user.Id,
                        DeliveryClientOrgUserRole = DeliveryClientOrgUserRole.Admin,
                        DeliveryClientOrganizationId= DeliveryClientOrgId
                    };

                    _managerRepository.DeliveryClientUser.CreateDeliveryClientUser(deliveryClientUser);

                    if (!await _managerRepository.SaveAsync())
                        throw new Exception("Failed To Create DeliveryClientUser");

                    bool IsDone = await _managerRepository.SaveAsync();

                    if(!IsDone)
                        throw new Exception("Failed to create user for Client");

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
