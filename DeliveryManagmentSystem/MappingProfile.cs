using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.DeliveryClientOrganization;
using Shared.DataTransferObjects.DeliveryClientUser;
using Shared.DataTransferObjects.DeliveryCompany;
using Shared.DataTransferObjects.DeliveryCompanyUser;
using Shared.DataTransferObjects.Driver;
using Shared.DataTransferObjects.User;
using Shared.InternalModels;
using System.ComponentModel;

namespace DeliveryManagmentSystem
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForAuthenticationResponse>()
               .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UserPreRegisterRequest, User>();
            CreateMap<UserPreRegisterRequest, UserPreRegisterResponse>();
            CreateMap<UserForRegisterationRequest,User>();

            CreateMap<UserForAuthenticationResponse, DeliveryClientUserDto>();
            CreateMap<UserForAuthenticationResponse, DeliveryCompanyUserDto>();

            CreateMap<AddDeliveryCompanyRequest, DeliveryCompany>();
            CreateMap<AddDeliveryClientOrganizationRequest, DeliveryClientOrganization>();
            CreateMap<Driver, AddDriverRequest>();
            CreateMap<DeliveryCompanyUser, DeliveryCompanyUserModel>();
            CreateMap<DeliveryClientUser, DeliveryClientUserModel>();
        }
    }
}
