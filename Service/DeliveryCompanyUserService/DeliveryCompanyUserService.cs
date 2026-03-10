using AutoMapper;
using Contracts;
using Entities.Models;
using Enums;
using Service.Contracts;
using Shared.DataTransferObjects.DeliveryCompany;
using Shared.DataTransferObjects.DeliveryCompanyUser;
using Shared.DataTransferObjects.User;
using Shared.InternalModels;

namespace Service.DeliveryCompanyUserService
{
    public class DeliveryCompanyUserService : IDeliveryCompanyUser
    {
        private readonly IAuthService _authService;
        private readonly IManagerRepository _managerRepository;
        private readonly IDeliveryCompany _deliveryCompany;
        private readonly IMapper _mapper;

        public DeliveryCompanyUserService(IAuthService authService, IManagerRepository managerRepository, IMapper mapper, IDeliveryCompany deliveryCompany)
        {
            _authService = authService;
            _managerRepository = managerRepository;
            _mapper = mapper;
            _deliveryCompany = deliveryCompany;
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

        private async Task<bool> SetDeliveryCompanyToUser(Guid ProfileId, Guid DeliveryCompanyId)
        {
            DeliveryCompanyUser deliveryCompanyUser = await _managerRepository.DeliveryCompanyUser.GetDeliveryCompanyUser(ProfileId, true);

            deliveryCompanyUser.DeliveryCompanyId = DeliveryCompanyId;

            _managerRepository.DeliveryCompanyUser.UpdateDeliveryCompanyUser(deliveryCompanyUser);

            return await _managerRepository.SaveAsync();
        }

        public async Task<bool> HandleCreateCompanyForUser(AddDeliveryCompanyRequest addDeliveryCompanyRequest,Guid ProfileId)
        {
            using(var transaction = await  _managerRepository.BeginTransactionAsync())
            {
                try
                {
                    Guid? DeliveryCompanyId = await _deliveryCompany.CreateDeliveryCompany(addDeliveryCompanyRequest);

                    if (DeliveryCompanyId is null)
                        throw new Exception("Failed to Create Delivery Company!");

                    bool IsDone = await SetDeliveryCompanyToUser(ProfileId, DeliveryCompanyId.Value);

                    if(IsDone)
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

        public async Task<Guid?> GetUserDeliveryCompanyId(Guid ProfileId)
        {
            DeliveryCompanyUser deliveryCompanyUser = await _managerRepository.DeliveryCompanyUser.GetDeliveryCompanyUser(ProfileId, false);

            return deliveryCompanyUser.DeliveryCompanyId;
        }

        public async Task<DeliveryCompanyUserModel> GetDeliveryCompanyUserModel(Guid ProfileId)
        {
           DeliveryCompanyUser deliveryCompanyUser = await _managerRepository.DeliveryCompanyUser.GetDeliveryCompanyUser(ProfileId, false);

           return _mapper.Map<DeliveryCompanyUserModel>(deliveryCompanyUser);    
        }
    }
}

