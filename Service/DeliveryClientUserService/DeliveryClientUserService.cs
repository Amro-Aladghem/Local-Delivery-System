using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Models;
using Enums;
using AutoMapper;

namespace Service.DeliveryClientUserService
{
    public class DeliveryClientUserService : IDeliveryClientUser
    {
        private readonly IAuthService _authService;
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public DeliveryClientUserService(IAuthService authService, IManagerRepository managerRepository,IMapper mapper)
        {
            _authService = authService;
            _managerRepository = managerRepository;
            _mapper = mapper;
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
    }
}
