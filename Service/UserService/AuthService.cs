using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects.User;
using System.Data;
using System.Threading.Tasks;

namespace Service.UserService
{
    public class AuthService : IAuthService
    {
        enum eAuthWith { Email, Phone }

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthService(UserManager<User> userManager, IMapper mapper, ILogger logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserForAuthenticationResponse> AuthenticateUser(UserForAuthenticationRequest request)
        {
            eAuthWith eAuthWith = string.IsNullOrEmpty(request.Email) ? eAuthWith.Phone : eAuthWith.Email;

            User ? user =  eAuthWith switch
            {
                eAuthWith.Email => await _userManager.FindByEmailAsync(request.Email),
                eAuthWith.Phone => await _userManager.Users.FirstOrDefaultAsync(U=>U.PhoneNumber==request.PhoneNumber),
                _=>null
            };

            if (user is null)
                throw new UserNotFound(request.Email);

            var userRoles = await  _userManager.GetRolesAsync(user);

            UserForAuthenticationResponse response = _mapper.Map<User,UserForAuthenticationResponse>(user);
            response.SystemRole = userRoles[0];

            return response;
        }

        public async Task<UserPreRegisterResponse> PreRegisterUser(UserPreRegisterRequest request)
        {
            User user = _mapper.Map<UserPreRegisterRequest,User>(request);
            user.IsActive = false;

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception("Failed to save user at PreRegisterUser");

            var roleResult = await _userManager.AddToRoleAsync(user,request.SystemRole);

            if(!roleResult.Succeeded)
                throw new Exception("Failed to save user role at PreRegisterUser");

            UserPreRegisterResponse response = _mapper.Map<UserPreRegisterRequest, UserPreRegisterResponse>(request);
            response.UserId = user.Id;

            return response;
        }

        public async Task<UserForAuthenticationResponse> RegisterUser(UserForRegisterationRequest request)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(U => U.Id == request.UserId &&U.IsActive ==false);
            if (user is null)
                throw new UserNotFound(request.UserId.ToString());

            _mapper.Map(request, user);
            user.IsActive = true;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new Exception($"Failed to register the user with Id={user.Id}");

            var userRoles = await _userManager.GetRolesAsync(user);

            UserForAuthenticationResponse response = _mapper.Map<User, UserForAuthenticationResponse>(user);
            response.SystemRole = userRoles[0];

            return response;
        }
    }
}
