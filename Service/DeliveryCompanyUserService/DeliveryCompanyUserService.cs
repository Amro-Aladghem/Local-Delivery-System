using AutoMapper;
using Contracts;
using Entities.Models;
using Enums;
using Repository;
using Service.Contracts;
using Service.UserService;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompanyUser;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DeliveryCompanyUserService
{
    public class DeliveryCompanyUserService : IDeliveryCompanyUser
    {
        private readonly IAuthService _authService;
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public DeliveryCompanyUserService(IAuthService authService, IManagerRepository managerRepository, IMapper mapper)
        {
            _authService = authService;
            _managerRepository = managerRepository;
            _mapper = mapper;
        }
        private RegisterDeliveryCompanyUserResult? MappingRegisterUser(UserForAuthenticationResponse authUser, TokenDto tokenDto)
        {
            DeliveryCompanyUserDto deliveryClientUser = _mapper.Map<DeliveryCompanyUserDto>(authUser);

            return new RegisterDeliveryCompanyUserResult() { DeliveryCompanyUserDto = deliveryClientUser, TokenDto = tokenDto };
        }

        public async Task<RegisterDeliveryCompanyUserResult?> CreateDeliveryCompanyUser(AddDeliveryCompanyUserDto request, Guid PreRegisterUserId)
        {
            using (var transaction = await _managerRepository.BeginTransactionAsync())
            {
                try
                {
                    UserForAuthenticationResponse? authUser = await _authService.RegisterUser(request, PreRegisterUserId, SystemUserRoles.DeliveryClient.ToString());

                    if (authUser is null)
                        throw new Exception("Failed To Register User");

                    DeliveryCompanyUser deliveryCompanyUser = new DeliveryCompanyUser()
                    {
                        UserId = authUser.Id,
                        DeliveryCompanyUserRole = DeliveryCompanyUserRole.Manager
                    };

                    _managerRepository.DeliveryCompanyUser.CreateDeliveryCompanyUser(deliveryCompanyUser);

                    if (!await _managerRepository.SaveAsync())
                        throw new Exception("Failed To Create DeliveryClientUser");

                    TokenDto? tokenDto = await _authService.GenerateTokenForUser(deliveryCompanyUser.UserId, deliveryCompanyUser.Id);

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
    }
}

