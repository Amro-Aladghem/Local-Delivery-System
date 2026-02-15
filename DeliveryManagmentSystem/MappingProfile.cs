using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.User;
using System.ComponentModel;

namespace DeliveryManagmentSystem
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForAuthenticationResponse>()
               .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UserPreRegisterRequest, User>();
            CreateMap<UserPreRegisterRequest, UserPreRegisterResponse>();
            CreateMap<UserForRegisterationRequest,User>();
      
        }
    }
}
